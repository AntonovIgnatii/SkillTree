using Cores.Currencies;
using Templates.Currencies;
using UnityEngine;
using UnityEngine.UI;

namespace Cores.Ui
{
    public class CollectView : UiView
    {
        [SerializeField] private Button m_CollectButton;
        [SerializeField] private int m_EarnCount;

        public override void Initialize()
        {
            base.Initialize();
            
            m_CollectButton.onClick.AddListener(Earn);
        }

        private void Earn()
        {
            CurrenciesData.Data().GetCurrency<Experience>().Earn(m_EarnCount);
            CurrenciesData.Save();
        }
        
        private void OnDestroy()
        {
            m_CollectButton.onClick.RemoveAllListeners();
        }
    }
}