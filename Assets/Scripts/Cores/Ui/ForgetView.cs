using Templates.Products;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cores.Ui
{
    public class ForgetView : UiView
    {
        [SerializeField] private Button m_ForgetButton;
        [SerializeField] private TextMeshProUGUI m_ForgetText;
        
        private Product _product;
        
        public override void Initialize()
        {
            base.Initialize();
            
            m_ForgetButton.onClick.AddListener(Forget);
        }

        public void Activate(bool value, Product product)
        {
            m_ForgetButton.gameObject.SetActive(value);
            _product = product;
            
            if (value)
            {
                m_ForgetText.text = $"Forget: +{product.Cost}";
            }
        }
        
        private void Forget()
        {
            _product?.RevertProduct();
        }
    }
}
