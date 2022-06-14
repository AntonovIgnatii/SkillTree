using UnityEngine;

namespace Cores.Skills.Configs
{
    [CreateAssetMenu(menuName = "Custom/SkillColorConfig", fileName = "New Skill Color")]
    public class SkillColorConfig : ScriptableObject
    {
        [SerializeField] private SkillColorInfo m_Info;

        public SkillColorInfo Info => m_Info;
    }
}