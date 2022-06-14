using Cores.Skills.Configs;
using Cores.Skills.Graph;
using UnityEngine;
using UnityEngine.UI;

namespace Cores.SkillTrees
{
    public class SkillView : MonoBehaviour, IHaveID
    {
        [SerializeField] private int m_ID;
        [SerializeField] private Image m_TargetImage;

        [SerializeField] private SkillColorConfig m_SkillColorConfig; 
        
        private bool _isExplore;

        public int ID => m_ID;

        public void Initialize()
        {
            m_TargetImage.color = _isExplore ? m_SkillColorConfig.Info.ExploreColor : m_SkillColorConfig.Info.ForgetColor;
        }

        public void Select()
        {
            m_TargetImage.color = m_SkillColorConfig.Info.ActiveColor; 
        }
        
        public void Deselect()
        {
            m_TargetImage.color =_isExplore ? m_SkillColorConfig.Info.ExploreColor : m_SkillColorConfig.Info.ForgetColor; 
        }

        public void OnStateChanged(bool isExplore)
        {
            _isExplore = isExplore;
            m_TargetImage.color = _isExplore ? m_SkillColorConfig.Info.ExploreColor : m_SkillColorConfig.Info.ForgetColor;
        }
    }
}