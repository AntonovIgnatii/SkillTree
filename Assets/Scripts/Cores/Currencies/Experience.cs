using System;
using Templates.Currencies;

namespace Cores.Currencies
{
    [Serializable]
    public class Experience : Currency
    {
        public Experience()
        {
            
        }

        public Experience(int defaultCount)
        {
            m_Count = defaultCount;
        }
    }
}