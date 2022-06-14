using UnityEngine;

namespace Cores.Skills.Configs
{
    [CreateAssetMenu(menuName = "Custom/SkillNode", fileName = "New Skill Node")]
    public class SkillNodeConfig : ScriptableObject
    {
        [SerializeField] private SkillNodeInfo m_NodeInfo;

        public SkillNodeInfo NodeInfo => m_NodeInfo;
    }
}