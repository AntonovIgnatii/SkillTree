using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Cores.Management
{
    public class UserInputController : MonoBehaviour
    {
        public event Action<GameObject> onTargetFind;

        private int _uiLayer;
 
        public void Initialize()
        {
            _uiLayer = LayerMask.NameToLayer("UI");
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                FindTarget();
            }
        }

        private void FindTarget()
        {
            var rayResult = GetEventSystemRaycastResults();

            if (rayResult == null || rayResult.Count < 1)
            {
                onTargetFind?.Invoke(null);
                return;
            }

            if (rayResult[0].gameObject.layer == _uiLayer)
            {
                return;
            }
            
            onTargetFind?.Invoke(rayResult[0].gameObject);
        }
        
        private List<RaycastResult> GetEventSystemRaycastResults()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> raycastResults = new List<RaycastResult>();
           
            EventSystem.current.RaycastAll(eventData, raycastResults);
          
            return raycastResults;
        }
    }
}