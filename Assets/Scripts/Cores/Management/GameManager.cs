using UnityEngine;

namespace Cores.Management
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private SkillController m_SkillController;
        [SerializeField] private UserInputController m_UserInputController;
        [SerializeField] private UiController m_UiController;
        
        private void Awake()
        {
            m_UserInputController.onTargetFind += m_SkillController.OnSelect;
            m_SkillController.onCanExplore += m_UiController.ActivateExploreUi;
            m_SkillController.onCanForget += m_UiController.ActivateForgetUi;
                
            m_UserInputController.Initialize();
            m_UiController.Initialize();
            m_SkillController.Initialize();
        }
    }
}
