using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Cores.SkillTrees.Configs
{
    [Serializable]
    public class SkillTreeInfo
    {
        [SerializeField] private List<SkillNodeConfig> m_SkillNodes = new ();

        public ReadOnlyCollection<SkillNodeConfig> SkillNodes => new (m_SkillNodes);
    }
}