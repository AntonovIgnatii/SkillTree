﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cores.SkillTrees.Configs;
using UnityEngine;

namespace Cores.SkillTrees.Save
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