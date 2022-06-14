using System;
using System.Collections.Generic;
using Cores.Skills.Configs;
using Cores.Skills.Graph;
using Cores.SkillTrees;
using Templates.Products;
using UnityEngine;

namespace Cores.Management
{
    public class SkillController : MonoBehaviour
    {
        public event Action<bool, Product> onCanExplore, onCanForget;

        [SerializeField] private SkillTreeConfig m_SkillTreeConfig;
        [SerializeField] private List<SkillView> m_Views = new ();

        [SerializeField] private ProductConfig m_ForgetAllProduct;
        
        private readonly List<int> _baseSkillIds = new ();
        private readonly List<int> _exploredSkillIds = new ();
        
        private SkillGraph _tree;

        private SkillView _selectedSkillView;
        
        public void Initialize()
        {
            m_SkillTreeConfig.Load();

            _tree = new SkillGraph();
            
            var skillNodes = m_SkillTreeConfig.Data.SkillNodes;
            
            foreach (var node in skillNodes)
            {
                if (node.NodeInfo.IsBaseSkill)
                {
                    _baseSkillIds.Add(node.NodeInfo.ID);
                    continue;
                }

                if (node.NodeInfo.IsExplore)
                {
                    _exploredSkillIds.Add(node.NodeInfo.ID);
                }
                
                node.NodeInfo.GetProduct.onProductIsBuy += Explore;
                node.NodeInfo.GetProduct.onProductIsRevert += Forget;
                
                _tree.Add(node.NodeInfo);
            }

            foreach (var view in m_Views)
            {
                view.Initialize();
                
                if (_baseSkillIds.Contains(view.ID) || _exploredSkillIds.Contains(view.ID))
                {
                    view.OnStateChanged(true);
                }
            }

            m_ForgetAllProduct.GetProduct.onProductIsBuy += ForgetAll;
        }
        
        public void OnSelect(GameObject selectObject)
        {
            if (_selectedSkillView != null)
            {
                _selectedSkillView.Deselect();
            }
            
            if (selectObject == null)
            {
                Deselect();
                return;
            }

            Select(selectObject);
        }

        private void Deselect()
        {
            _selectedSkillView = null;
            
            onCanExplore?.Invoke(false, null);
            onCanForget?.Invoke(false, null);
        }

        private void Select(GameObject selectObject)
        {
            SkillView selectView = selectObject.GetComponent<SkillView>();
            if (selectView == null)
            {
                Deselect();
                return;
            }

            if (_selectedSkillView == selectView)
            {
                Deselect();
                return;
            }
            
            _selectedSkillView = selectView;
            _selectedSkillView.Select();
            
            onCanExplore?.Invoke(CanExplore(_selectedSkillView), _tree[_selectedSkillView]?.GetProduct);
            onCanForget?.Invoke(CanForget(_selectedSkillView), _tree[_selectedSkillView]?.GetProduct);
        }
        
        private bool CanExplore(IHaveID nodeContainer)
        {
            if (nodeContainer == null)
            {
                return false;
            }
            return _tree.IsMayBeExplore(nodeContainer);
        }
        
        private void Explore()
        {
            _tree[_selectedSkillView].SetExplore(true);
            _selectedSkillView.OnStateChanged(true);
                
            onCanExplore?.Invoke(false, null);
            
            _selectedSkillView.Deselect();
            _selectedSkillView = null;
            
            m_SkillTreeConfig.Save();
        }

        private bool CanForget(IHaveID nodeContainer)
        {
            if (nodeContainer == null)
            {
                return false;
            }
            return _tree.IsMayBeForgotten(nodeContainer);
        }

        private void Forget()
        {
            _tree[_selectedSkillView].SetExplore(false);
            _selectedSkillView.OnStateChanged(false);
            
            onCanForget?.Invoke(false, null);
            
            _selectedSkillView.Deselect();
            _selectedSkillView = null;
            
            m_SkillTreeConfig.Save();
        }

        private void ForgetAll()
        {
            if (_selectedSkillView)
            {
                _selectedSkillView.Deselect();
                _selectedSkillView = null;   
            }

            var skillNodes = m_SkillTreeConfig.Data.SkillNodes;
            
            foreach (var node in skillNodes)
            {
                if (node.NodeInfo.IsBaseSkill)
                {
                    continue;
                }
                
                if (node.NodeInfo.IsExplore)
                {
                    node.NodeInfo.GetProduct.onProductIsRevert -= Forget;
                    node.NodeInfo.GetProduct.RevertProduct();
                    node.NodeInfo.SetExplore(false);
                    
                    node.NodeInfo.GetProduct.onProductIsRevert += Forget;
                }
            }
            
            foreach (var view in m_Views)
            {
                if (_baseSkillIds.Contains(view.ID))
                {
                    continue;
                }
                
                view.OnStateChanged(false);
            }
            
            m_SkillTreeConfig.Save();
        }
    }
}