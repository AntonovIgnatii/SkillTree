using System;
using Cores.Currencies;
using Templates.Currencies;
using UnityEngine;

namespace Templates.Products
{
    [Serializable]
    public class Product
    {
        [field: NonSerialized] public event Action onProductIsBuy;
        [field: NonSerialized] public event Action onProductIsRevert;
        
        [SerializeField] private int m_Cost;

        public int Cost => m_Cost;
        
        public void BuyProduct()
        {
            if (CurrenciesData.Data().GetCurrency<Experience>().Spend(m_Cost))
            {
                CurrenciesData.Save();
                onProductIsBuy?.Invoke();
            }
        }

        public void RevertProduct()
        {
            CurrenciesData.Data().GetCurrency<Experience>().Earn(m_Cost);
            CurrenciesData.Save();
            
            onProductIsRevert?.Invoke();
        }
    }
}
