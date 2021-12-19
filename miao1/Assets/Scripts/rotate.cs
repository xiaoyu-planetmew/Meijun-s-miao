using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine.EventSystems;

namespace Kernal
{
   public class rotate : MonoBehaviour, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
           
            SetDraggedRotation(eventData);
        }

        private void SetDraggedRotation(PointerEventData eventData)
        {
            Vector2 curSelfScreenPosition = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera, transform.position);
            Vector2 directionTo = curSelfScreenPosition - eventData.position;
            Vector2 directionFrom = directionTo - eventData.delta;
            this.transform.rotation *= Quaternion.FromToRotation(directionTo, directionFrom);
        }


    }
}