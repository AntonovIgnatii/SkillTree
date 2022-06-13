using System;
using System.Collections.Generic;
using Cores.SkillTrees.Configs;

namespace Cores.SkillTrees.Trees
{
    public class CustomTree : IDisposable
    {
        private readonly Dictionary<int, SkillNodeInfo> _nodes = new ();

        public void Add(SkillNodeInfo value)
        {
            if (_nodes.ContainsKey(value.ID))
            {
                return;
            }

            _nodes.Add(value.ID, value);
        }

        public SkillNodeInfo this[IHaveID nodeContainer]
        {
            get
            {
                if (nodeContainer == null)
                {
                    return null;
                }

                if (_nodes.TryGetValue(nodeContainer.ID, out var nodeInfo))
                {
                    return nodeInfo;
                }

                return null;
            }
        }

        private bool IsExplore(IHaveID nodeContainer)
        {
            if (nodeContainer == null)
            {
                return false;
            }

            if (_nodes.TryGetValue(nodeContainer.ID, out var nodeInfo))
            {
                return nodeInfo.IsExplore;
            }

            return false;
        }

        public bool IsMayBeForgotten(IHaveID nodeContainer)
        {
            return IsExplore(nodeContainer) && IsHeadRuleConfirm(nodeContainer) && IsTailRuleConfirm(nodeContainer);
        }

        public bool IsMayBeExplore(IHaveID nodeContainer)
        {
            return !IsExplore(nodeContainer) && IsTailRuleConfirm(nodeContainer);
        }

        private bool IsHeadRuleConfirm(IHaveID nodeContainer)
        {
            if (nodeContainer == null)
            {
                return false;
            }
            
            if (_nodes.TryGetValue(nodeContainer.ID, out var currentNode) == false)
            {
                return false;
            }

            var headNodes = currentNode.HeadNodes;
            if (headNodes == null || headNodes.Count == 0)
            {
                return true;
            }

            foreach (var headNode in headNodes)
            {
                if (headNode.NodeInfo.IsExplore && IsTailRuleConfirm(headNode.NodeInfo, currentNode) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsTailRuleConfirm(IHaveID nodeContainer, IHaveID ignoreNode = null)
        {
            if (nodeContainer == null)
            {
                return false;
            }
            
            if (_nodes.TryGetValue(nodeContainer.ID, out var currentNode) == false)
            {
                return false;
            }

            var tailNodes = currentNode.TailNodes;
            if (tailNodes == null || tailNodes.Count == 0)
            {
                return false;
            }

            foreach (var tailNode in tailNodes)
            {
                if (ignoreNode != null && ignoreNode.ID == tailNode.NodeInfo.ID)
                {
                    continue;
                }
                
                if (tailNode.NodeInfo.IsExplore)
                {
                    return true;
                }
            }

            return false;
        }


        public void Dispose()
        {
            if (_nodes == null || _nodes.Count < 1)
            {
                return;
            }

            _nodes.Clear();
        }
    }
}
