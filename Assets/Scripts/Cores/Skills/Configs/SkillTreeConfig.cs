using System.Collections.Generic;
using System.Linq;
using Cores.SkillTrees.Save;
using Templates.Saves;
using UnityEngine;

namespace Cores.Skills.Configs
{
    [CreateAssetMenu(menuName = "Custom/SkillTree", fileName = "New Skill Tree")]
    public class SkillTreeConfig : ScriptableObject
    {
        [SerializeField] private SkillTreeInfo m_Data;
        
        public SkillTreeInfo Data => m_Data;

        private void Clear()
        {
            foreach (var skillNode in m_Data.SkillNodes)
            {
                skillNode.NodeInfo.SetExplore(false);
            }
        }
        
        public void Load()
        {
            Clear();
            
            SkillData data = new SkillData();
            BinarySerialization.Load(ref data, "skillTree");

            Dictionary<int, bool> savePair = data.SkillInfos.ToDictionary(pair => pair.ID, pair => pair.IsExplore);
            foreach (var skillNode in m_Data.SkillNodes)
            {
                if (savePair.TryGetValue(skillNode.NodeInfo.ID, out var isExplore))
                {
                    skillNode.NodeInfo.SetExplore(isExplore);   
                }
            }
        }

        public void Save()
        {
            SkillData data = new SkillData();

            foreach (var skillNode in m_Data.SkillNodes)
            {
                if (skillNode.NodeInfo.IsExplore)
                {
                    data.AddSkillInfo(skillNode.NodeInfo);
                }
            }
            
            BinarySerialization.Save(data, "skillTree");
        }
    }
}