using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var values = line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var parentKey = values[0];
                var childKey = values[1];

                this.AddEdge(parentKey, childKey);
            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!this.nodesBykeys.ContainsKey(key))
            {
                this.nodesBykeys.Add(key, new Tree<int>(key));
            }

            return this.nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.CreateNodeByKey(parent);
            var childNode = this.CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        private Tree<int> GetRoot()
        {
            foreach (var kvp in this.nodesBykeys)
            {
                if (kvp.Value.Parent == null)
                {
                    return kvp.Value;
                }
            }

            return null;
        }
    }
}
