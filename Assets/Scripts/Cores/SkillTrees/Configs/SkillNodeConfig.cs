using UnityEngine;

namespace Cores.SkillTrees.Configs
{
    [CreateAssetMenu(menuName = "Custom/SkillNode", fileName = "New Skill Node")]
    public class SkillNodeConfig : ScriptableObject
    {
        [SerializeField] private SkillNodeInfo m_NodeInfo;

        public SkillNodeInfo NodeInfo => m_NodeInfo;
    }
}