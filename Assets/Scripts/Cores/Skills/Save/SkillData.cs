using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cores.Skills.Configs;
using UnityEngine;

namespace Cores.Skills.Save
{
    [Serializable]
    public class SkillData
    {
        [SerializeField] private List<SkillInfo> m_SkillInfos = new ();

        public ReadOnlyCollection<SkillInfo> SkillInfos => new (m_SkillInfos);

        public void AddSkillInfo(SkillNodeInfo nodeInfo)
        {
            m_SkillInfos.Add(new SkillInfo(nodeInfo.ID, nodeInfo.IsExplore));
        }
    }
}