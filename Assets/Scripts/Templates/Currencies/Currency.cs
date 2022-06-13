using System;
using UnityEngine;

namespace Templates.Currencies
{
    public delegate void CurrencyCountChanged(int value);

    public delegate void InvalidTrade(int value);
    
    [Serializable]
    public class Currency
    {
        [field: NonSerialized] public event CurrencyCountChanged onCurrencyCountChanged;
        [field: NonSerialized] public event InvalidTrade onInvalidTrade;
        
        [SerializeField] protected int m_Count;

        public int Count
        {
            get => m_Count;
            protected set
            {
                m_Count = Math.Clamp(value, 0, int.MaxValue);

                onCurrencyCountChanged?.Invoke(m_Count);
            }
        }

        public bool CanSpend(int value)
        {
            return m_Count - value >= 0;
        }

        public bool Spend(int value)
        {
            if (CanSpend(value) == false)
            {
                onInvalidTrade?.Invoke(m_Count - value);
                return false;
            }

            Count -= value;

            return true;
        }

        public void Earn(int value)
        {
            Count += value;
        }
    }
}