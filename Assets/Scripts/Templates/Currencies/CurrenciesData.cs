using System;
using System.Collections.Generic;
using Cores.Currencies;
using Templates.Saves;
using UnityEngine;

namespace Templates.Currencies
{
    [Serializable]
    public class CurrenciesData
    {
        [NonSerialized] private static CurrenciesData _data;
        public static CurrenciesData Data()
        {
            if (_data == null)
            {
                _data = new CurrenciesData();
                _data.Load();   
            }

            return _data;
        }
        
        [SerializeField] private List<Currency> m_Currencies;

        public CurrenciesData()
        {
            m_Currencies = new List<Currency>()
            {
                new Experience(3)
            };
        }


        private void Load()
        {
            BinarySerialization.Load(ref _data, "currencies");
        }

        public static void Save()
        {
            BinarySerialization.Save(_data, "currencies");
        }

        public Currency GetCurrency<T>() where T : Currency
        {
            if (m_Currencies == null || m_Currencies.Count < 1)
            {
                return null;
            }

            foreach (var currency in m_Currencies)
            {
                if (currency.GetType() == typeof(T))
                {
                    return currency;
                }
            }

            return null;
        }
    }
}