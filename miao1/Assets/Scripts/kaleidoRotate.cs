using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using UnityEngine.EventSystems;

//namespace Kernal
//{
   public class kaleidoRotate : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public bool canBeDrag = true;
        public bool draging;
        public Vector2 directionTo;
        public Vector2 directionFrom; 
        public Vector2 directionDelta; 
        public Vector2 cursePosition;
        public Camera pressEventCamera;
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
            directionTo = curSelfScreenPosition - eventData.position;
            cursePosition = eventData.position;
            pressEventCamera = eventData.pressEventCamera;
            directionDelta = eventData.delta;
            directionFrom = directionTo - eventData.delta;
            this.transform.rotation *= Quaternion.FromToRotation(directionTo, directionFrom);
            for(int i=0; i<this.transform.parent.gameObject.GetComponent<kaledoControl>().rings.Count; i++)
            {
                if(!this.transform.parent.gameObject.GetComponent<kaledoControl>().rings[i].GetComponent<kaleidoRotate>().draging)
                {
                    this.transform.parent.gameObject.GetComponent<kaledoControl>().rings[i].GetComponent<kaleidoRotate>().passiveRotation(
                    new Vector2
                    (directionDelta.x/(this.transform.parent.gameObject.GetComponent<kaledoControl>().directions[this.transform.parent.gameObject.GetComponent<kaledoControl>().activedRingNum]) 
                    * (this.transform.parent.gameObject.GetComponent<kaledoControl>().directions[i]), 
                    directionDelta.y/(this.transform.parent.gameObject.GetComponent<kaledoControl>().directions[this.transform.parent.gameObject.GetComponent<kaledoControl>().activedRingNum]) 
                    * (this.transform.parent.gameObject.GetComponent<kaledoControl>().directions[i])),
                    cursePosition,
                    pressEventCamera);
                }
            }
            draging = true;
        }
        public void passiveRotation(Vector2 directionDeltaFromActivedRing, Vector2 cursePositionFromActivedRing, Camera pressEventCameraFromActivedRing)
        {
            Vector2 curSelfScreenPosition = RectTransformUtility.WorldToScreenPoint(pressEventCameraFromActivedRing, transform.position);
            directionTo = curSelfScreenPosition - cursePositionFromActivedRing;
            //directionDelta = eventData.delta;
            directionFrom = directionTo - directionDeltaFromActivedRing;
            this.transform.rotation *= Quaternion.FromToRotation(directionTo, directionFrom);
        }
    }
//}