using System.Net.Mail;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
            this.IsRootDeleted = false;
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public bool IsRootDeleted { get; private set; }

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();

            if (this.IsRootDeleted)
            {
                return result;
            }
            
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.Value);

                foreach (var child in subtree.Children)
                    queue.Enqueue(child);
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();

            if (this.IsRootDeleted)
            {
                return result;
            }

            this.Dfs(this, result);

            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindBfs(parentKey);

            this.CheckEmptyNode(parentNode);

            parentNode._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var node = this.FindBfs(nodeKey);
            this.CheckEmptyNode(node);

            foreach (var child in node.Children)
            {
                child.Parent = null;
            }

            node._children.Clear();

            var parentNode = node.Parent;

            if (parentNode == null)
            {
                this.IsRootDeleted = true;
            }
            else
            {
                parentNode._children.Remove(node);
            }

            node.Value = default;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = this.FindBfs(firstKey);
            var secondNode = this.FindBfs(secondKey);

            this.CheckEmptyNode(firstNode);
            this.CheckEmptyNode(secondNode);

            var parentFirst = firstNode.Parent;
            var parentSecond = secondNode.Parent;

            if (firstNode.Parent == null)
            {
                SwapRoot(secondNode);
                return;
            }

            if (secondNode.Parent == null)
            {
                SwapRoot(firstNode);
                return;
            }

            var indexOfFirst = parentFirst._children.IndexOf(firstNode);
            var indexOfSecond = parentSecond._children.IndexOf(secondNode);

            parentFirst._children[indexOfFirst] = secondNode;
            parentSecond._children[indexOfSecond] = firstNode;
        }

        private void SwapRoot(Tree<T> node)
        {
            this.Value = node.Value;
            this._children.Clear();

            foreach (var child in node.Children)
            {
                this._children.Add(child);
            }
        }

        private void Dfs(IAbstractTree<T> tree, ICollection<T> result)
        {
            foreach (var child in tree.Children)
            {
                this.Dfs(child, result);
            }

            result.Add(tree.Value);
        }

        private Tree<T> FindBfs(T value)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();

                if (subtree.Value.Equals(value))
                {
                    return subtree;
                }

                foreach (var child in subtree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private void CheckEmptyNode(Tree<T> parentNode)
        {
            if (parentNode == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
