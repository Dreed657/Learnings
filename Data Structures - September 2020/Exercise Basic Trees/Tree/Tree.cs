using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this._children = new List<Tree<T>>();

            foreach (var child in children)
            {
                this.AddParent(child);
                child.Parent = this;
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString() 
        {
            var sb = new StringBuilder();
            this.OrderDfsForString(0, sb, this);

            return sb.ToString().Trim();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var leafNodes = this.OrderBfs()
                .Where(node => this.IsLeaf(node));

            int deepestNodeDepth = 0;
            Tree<T> deepestNode = null;

            foreach (var node in leafNodes)
            {
                int currentDepth = this.GetDepthFromLeafParent(node);

                if (currentDepth > deepestNodeDepth)
                {
                    deepestNode = node;
                    deepestNodeDepth = currentDepth;
                }
            }

            return deepestNode;
        }

        public List<T> GetLeafKeys()
        {
            var result = new List<T>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (this.IsLeaf(currentNode))
                {
                    result.Add(currentNode.Key);
                }

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        public List<T> GetMiddleKeys()
        {
            var result = new List<T>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (this.IsMiddle(currentNode))
                {
                    result.Add(currentNode.Key);
                }

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = this.GetDeepestLeftomostNode();
            var resultPath = new List<T>();
            var currentNode = deepestNode;

            while (currentNode != null)
            {
                resultPath.Add(currentNode.Key);
                currentNode = currentNode.Parent;
            }

            resultPath.Reverse();

            return resultPath;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();
            var currentPath = new List<T>();
            currentPath.Add(this.Key);
            var currentSum = Convert.ToInt32(this.Key);
            this.GetPathsWithSumDfs(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var result = new List<Tree<T>>();
            var allNodes = this.OrderBfsNodes();

            foreach (var node in allNodes)
            {
                int subtreeSum = this.GetSubTreeSumDfs(node);

                if (subtreeSum == sum)
                {
                    result.Add(node);
                }
            }

            return result;
        }

        private int GetSubTreeSumDfs(Tree<T> node)
        {
            int currentSum = Convert.ToInt32(node.Key);
            int childSum = 0;

            foreach (var child in node.Children)
            {
                childSum += this.GetSubTreeSumDfs(child);
            }

            return currentSum + childSum;
        }

        private void GetPathsWithSumDfs(Tree<T> current, List<List<T>> wantedPaths, List<T> currentPath, ref int currentSum, int wantedSum)
        {
            foreach (var child in current.Children)
            {
                currentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);
                this.GetPathsWithSumDfs(child, wantedPaths, currentPath, ref currentSum, wantedSum);
            }

            if (currentSum == wantedSum)
            {
                wantedPaths.Add(new List<T>(currentPath));
            }

            currentSum -= Convert.ToInt32(current.Key);
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private int GetDepthFromLeafParent(Tree<T> node)
        {
            int depth = 0;
            Tree<T> current = node;
            while (current.Parent != null)
            {
                depth++;
                current = current.Parent;
            }

            return depth;
        }

        private List<Tree<T>> OrderBfsNodes(Func<Tree<T>, bool> predicate = null)
        {
            var result = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                if (predicate != null)
                {
                    if (predicate.Invoke(currentNode))
                    {
                        result.Add(currentNode);
                    }
                }
                else
                {
                    result.Add(currentNode);
                }

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        private List<Tree<T>> OrderBfs()
        {
            var result = new List<Tree<T>>();
            var nodes = new Queue<Tree<T>>();

            nodes.Enqueue(this);

            while (nodes.Count > 0)
            {
                var currentNode = nodes.Dequeue();

                result.Add(currentNode);

                foreach (var child in currentNode.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return result;
        }

        private void OrderDfsForString(int depth, StringBuilder sb, Tree<T> subtree)
        {
            sb.AppendLine(new string(' ', depth) + subtree.Key);

            foreach (var child in subtree.Children)
            {
                this.OrderDfsForString(depth + 2, sb, child);
            }
        }

        private bool IsLeaf(Tree<T> node)
        {
            return node.Children.Count == 0;
        }

        private bool IsRoot(Tree<T> node)
        {
            return node.Parent == null;
        }

        private bool IsMiddle(Tree<T> node)
        {
            return node.Parent != null && node.Children.Count != 0;
        }
    }
}
