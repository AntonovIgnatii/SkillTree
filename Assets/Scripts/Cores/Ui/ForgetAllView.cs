using Templates.Products;
using UnityEngine;
using UnityEngine.UI;

namespace Cores.Ui
{
    public class ForgetAllView : UiView
    {
        [SerializeField] private Button m_ForgetAllButton;
        [SerializeField] private ProductConfig m_ForgetAllProduct;
        
        public override void Initialize()
        {
            base.Initialize();
            
            m_ForgetAllButton.onClick.AddListener(ForgetAll);
        }

        private void ForgetAll()
        {
            m_ForgetAllProduct.GetProduct.BuyProduct();
        }
    }
}
