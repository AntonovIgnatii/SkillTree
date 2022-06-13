using System;
using UnityEngine;

namespace Cores.SkillTrees.Configs
{
    [Serializable]
    public class SkillColorInfo
    {
        [SerializeField] private Color m_ExploreColor, m_ForgetColor, m_ActiveColor;

        public Color ExploreColor => m_ExploreColor;
        public Color ForgetColor => m_ForgetColor;
        public Color ActiveColor => m_ActiveColor;
    }
}