using Cores.Currencies;
using Templates.Currencies;
using TMPro;
using UnityEngine;

namespace Cores.Ui
{
    public class ExperiencePanelView : UiView
    {
        [SerializeField] private TextMeshProUGUI m_ExperienceText;

        public override void Initialize()
        {
            base.Initialize();
            
            CurrenciesData.Data().GetCurrency<Experience>().onCurrencyCountChanged += OnCurrencyCountChanged;
            OnCurrencyCountChanged(CurrenciesData.Data().GetCurrency<Experience>().Count);
        }

        private void OnCurrencyCountChanged(int count)
        {
            m_ExperienceText.text = count.ToString();
        }

        private void OnDestroy()
        {
            CurrenciesData.Data().GetCurrency<Experience>().onCurrencyCountChanged -= OnCurrencyCountChanged;
        }
    }
}
