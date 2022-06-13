using Templates.Products;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cores.Ui
{
    public class ExploreView : UiView
    {
        [SerializeField] private Button m_ExploreButton;
        [SerializeField] private TextMeshProUGUI m_ExploreText;
        
        private Product _product;
        
        public override void Initialize()
        {
            base.Initialize();
            
            m_ExploreButton.onClick.AddListener(Explore);
        }

        public void Activate(bool value, Product product)
        {
            m_ExploreButton.gameObject.SetActive(value);
            
            _product = product;

            if (value)
            {
                m_ExploreText.text = $"Explore: -{product.Cost}";   
            }
        }
        
        private void Explore()
        {
            _product?.BuyProduct();
        }
    }
}
