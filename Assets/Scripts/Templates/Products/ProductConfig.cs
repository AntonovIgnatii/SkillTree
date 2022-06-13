using UnityEngine;

namespace Templates.Products
{
    [CreateAssetMenu(menuName = "Custom/ProductConfig", fileName = "New Product Config")]
    public class ProductConfig : ScriptableObject
    {
        [SerializeField] private Product m_Product;
        
        public Product GetProduct => m_Product;
    }
}