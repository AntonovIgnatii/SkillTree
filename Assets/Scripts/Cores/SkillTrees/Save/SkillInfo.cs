using System;
using UnityEngine;

namespace Cores.SkillTrees.Save
{
    [Serializable]
    public class SkillInfo
    {
        public SkillInfo(int id, bool isExplore)
        {
            m_ID = id;
            m_IsExplore = isExplore;
        }
        
        [SerializeField] private int m_ID;
        [SerializeField] private bool m_IsExplore;

        public int ID => m_ID;
        public bool IsExplore => m_IsExplore;
    }
}