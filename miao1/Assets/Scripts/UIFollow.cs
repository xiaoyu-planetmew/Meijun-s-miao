using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollow : MonoBehaviour
{
    public Camera _camera;
    public GameObject target;
    public bool alwaysFollow = true;

    bool hasFollowed = false;
    public Canvas canvas;

    public void Init()
    {
        if(_camera.gameObject.activeInHierarchy)
        {
            FollowObject();
        }
        
    }

    public void Update()
    {
        if(_camera.gameObject.activeInHierarchy)
        {
            FollowObject();
        }
    }

    void FollowObject()
    {
        if (!alwaysFollow && hasFollowed)
            return;

        if (_camera != null && target != null)
        {
            Vector2 pos = _camera.WorldToScreenPoint(target.transform.position);
            Vector2 point;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent as RectTransform, pos, canvas.worldCamera, out point))
            {
                transform.localPosition = new Vector3(point.x + 40.48f, -16.87845f, 0);
                hasFollowed = true;
            }
        }
    }
}
