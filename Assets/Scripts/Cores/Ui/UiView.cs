using UnityEngine;

namespace Cores.Ui
{
    public abstract class UiView : MonoBehaviour
    {
        [SerializeField] protected bool m_ActiveOnStart;
        [SerializeField] protected GameObject m_ViewPlace;

        public virtual void Initialize()
        {
            if (m_ActiveOnStart == false)
            {
                Hide();
            }
        }

        public virtual void Hide()
        {
            m_ViewPlace.gameObject.SetActive(false);
        }

        public virtual void Show()
        {
            m_ViewPlace.gameObject.SetActive(true);
        }
    }
}