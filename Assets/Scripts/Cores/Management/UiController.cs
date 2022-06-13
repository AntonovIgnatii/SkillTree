using System.Collections.Generic;
using Cores.Ui;
using Templates.Products;
using UnityEngine;

namespace Cores.Management
{
    public class UiController : MonoBehaviour
    {
        [SerializeField] private List<UiView> m_UiViews = new ();

        private ExploreView _exploreView;
        private ForgetView _forgetView;
        
        public void Initialize()
        {
            foreach (var uiView in m_UiViews)
            {
                if (uiView.GetType() == typeof(ExploreView))
                {
                    _exploreView = uiView as ExploreView;
                }
                
                if (uiView.GetType() == typeof(ForgetView))
                {
                    _forgetView = uiView as ForgetView;
                }
                
                uiView.Initialize();
            }
        }

        public void ActivateExploreUi(bool active, Product product)
        {
            _exploreView.Activate(active, product);
        }

        public void ActivateForgetUi(bool active, Product product)
        {
            _forgetView.Activate(active, product);
        }
    }
}