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
    public bool right;
        public Vector2 directionTo;
        public Vector2 directionFrom; 
        public Vector2 directionDelta; 
        public Vector2 cursePosition;
        public Camera pressEventCamera;
        public List<float> angles = new List<float>();
        void Update()
        {
            
            //Debug.Log(i);
            //Debug.Log((Mathf.Abs(this.transform.localEulerAngles.z - angles[i])));
                if((this.transform.localEulerAngles.z < 5 || this.transform.localEulerAngles.z > 355) && !draging)
                {
                    right = true;
                    //Debug.Log(angles[i]);
                }
                else
                {
                    right = false;
                }
            
            
            if (this.transform.parent.GetComponent<kaledoControl>().groupRight)
            {
            //this.transform.eulerAngles
                this.transform.rotation = Quaternion.AngleAxis(0, Vector3.zero);
                //this.transform.eulerAngles = Vector3.MoveTowards(this.transform.eulerAngles, new Vector3(0, 0, 0), Time.deltaTime * 5f);
            }
        }
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
                    this.transform.parent.gameObject.GetComponent<kaledoControl>().rings[i].GetComponent<kaleidoRotate>().passiveRotation(directionTo, directionFrom, this.transform.parent.gameObject.GetComponent<kaledoControl>().directions[i]);
                }
            }
            /*for(int i=0; i<this.transform.parent.gameObject.GetComponent<kaledoControl>().rings.Count; i++)
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
            }*/
            draging = true;
        }
        public Quaternion passiveFromToRotation(Vector2 u, Vector2 v, float speed)
        {
            float lTheta = Vector2.Dot(u.normalized, v.normalized);

            if (lTheta >= 1f)
            {
                return Quaternion.identity;
            } 
            else if (lTheta <= -1f)
            {
                Vector3 lSimpleAxis = Vector3.Cross(u,  Vector3.right);
                if (lSimpleAxis.sqrMagnitude == 0f) { lSimpleAxis = Vector3.Cross(u, Vector3.up); }

                return Quaternion.AngleAxis(180f, lSimpleAxis);
            }

            float lRadians = Mathf.Acos(lTheta) * speed;
            Vector3 lAxis = Vector3.Cross(u, v);

            return Quaternion.AngleAxis(lRadians * Mathf.Rad2Deg, lAxis);
        }
        public void passiveRotation(Vector2 directionDeltaFromActivedRing, Vector2 cursePositionFromActivedRing, float speed)
        {
            /*
            Vector2 curSelfScreenPosition = RectTransformUtility.WorldToScreenPoint(pressEventCameraFromActivedRing, transform.position);
            directionTo = curSelfScreenPosition - cursePositionFromActivedRing;
            //directionDelta = eventData.delta;
            directionFrom = directionTo - directionDeltaFromActivedRing;
            this.transform.rotation *= Quaternion.FromToRotation(directionTo, directionFrom);
            */
            this.transform.rotation *= passiveFromToRotation(directionDeltaFromActivedRing, cursePositionFromActivedRing, speed);
        }
    }
//}