using UnityEngine;

namespace Cores.SkillTrees.Configs
{
    [CreateAssetMenu(menuName = "Custom/SkillColorConfig", fileName = "New Skill Color")]
    public class SkillColorConfig : ScriptableObject
    {
        [SerializeField] private SkillColorInfo m_Info;

        public SkillColorInfo Info => m_Info;
    }
}