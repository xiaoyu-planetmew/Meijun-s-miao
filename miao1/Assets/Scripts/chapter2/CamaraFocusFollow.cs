using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CamaraFocusFollow : MonoBehaviour
{
    public GameObject obj;
    public float yAxis;
    
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(obj.GetComponent<PlayerUnderWaterControl>().underWater)
        {
            this.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, this.transform.position.z);
        }
        if(!obj.GetComponent<PlayerUnderWaterControl>().underWater)
        {
            this.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + yAxis, this.transform.position.z);
        }
        if (obj.transform.position.x < -100)
        {
            if (obj.transform.position.x < -261)
            {
                if (cam.name == "Main Camera")
                {
                    cam.gameObject.GetComponent<CinemachineBrain>().enabled = false;
                    cam.transform.DOMove(new Vector3(-280f, 2.86f, -8.8f), 0.5f);
                    //cam.transform.position = new Vector3(-280f, 2.86f, -10f);
                    cam.fieldOfView = 100;
                    for(int i=0; i<DialogSys2.Instance.textBackgrounds.Count; i++)
                    {
                        DialogSys2.Instance.textBackgrounds[i].transform.localScale = new Vector3(58.67182f, 58.67182f, 58.67182f);
                    }
                }
            }
            else
            {
                if (cam.name == "Main Camera")
                {
                    cam.gameObject.GetComponent<CinemachineBrain>().enabled = true;
                    for(int i=0; i<DialogSys2.Instance.textBackgrounds.Count; i++)
                    {
                        DialogSys2.Instance.textBackgrounds[i].transform.localScale = new Vector3(51.114f, 51.114f, 51.114f);
                    }
                }
            }
        }
    }
}
