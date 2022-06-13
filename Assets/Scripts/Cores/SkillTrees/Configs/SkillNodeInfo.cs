using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cores.SkillTrees.Trees;
using Templates.Products;
using UnityEngine;

namespace Cores.SkillTrees.Configs
{
    [Serializable]
    public class SkillNodeInfo : IHaveID
    {
        [SerializeField] private int m_ID;
        [SerializeField] private bool m_IsExplore;
        [SerializeField] private Product m_Product;

        [SerializeField] private List<SkillNodeConfig> m_TailNodes = new();
        [SerializeField] private List<SkillNodeConfig> m_HeadNodes = new();

        public bool IsBaseSkill => m_TailNodes == null || m_TailNodes.Count < 1;
        
        public int ID => m_ID;
        public bool IsExplore
        {
            get
            {
                if (IsBaseSkill && m_IsExplore == false)
                {
                    m_IsExplore = true;
                }
                return m_IsExplore;
            }
            private set => m_IsExplore = value;
        }

        public Product GetProduct => m_Product;

        public ReadOnlyCollection<SkillNodeConfig> TailNodes => new(m_TailNodes);
        public ReadOnlyCollection<SkillNodeConfig> HeadNodes => new(m_HeadNodes);

        public void SetExplore(bool value)
        {
            IsExplore = value;
        }
    }
}