using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using UnityEngine.EventSystems;

//namespace Kernal
//{
   public class rotate : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public bool canBeDrag = true;
        public bool draging;
        public void OnDrag(PointerEventData eventData)
        {
           if(canBeDrag)
           {
                SetDraggedRotation(eventData);
           }
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            draging = false;
        }

        private void SetDraggedRotation(PointerEventData eventData)
        {
            Vector2 curSelfScreenPosition = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera, transform.position);
            Vector2 directionTo = curSelfScreenPosition - eventData.position;
            Vector2 directionFrom = directionTo - eventData.delta;
            this.transform.rotation *= Quaternion.FromToRotation(directionTo, directionFrom);
            draging = true;
        }


    }
//}