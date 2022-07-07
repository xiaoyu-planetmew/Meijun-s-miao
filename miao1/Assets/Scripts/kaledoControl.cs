using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaledoControl : MonoBehaviour
{
    public List<GameObject> rings = new List<GameObject>();
    public List<float> directions = new List<float>();
    //public List<float> ratios = new List<float>();
    public GameObject activedRing;
    public int activedRingNum;
    public float speed = 5;
    public bool groupDraging;
    public bool groupRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<rings.Count; i++)
        {
            if(rings[i].GetComponent<kaleidoRotate>().draging){
                activedRing = rings[i];
                activedRingNum = i;
            }
        }
        rotateStop();
        rotateRight();
    }
    void rotateStop()
    {
        for(int i=0; i<rings.Count; i++)
        {
            if(rings[i].GetComponent<kaleidoRotate>().draging == true)
            {
                groupDraging = true;
                return;
                //Debug.Log("r1");
            }else
            {
                groupDraging = false;
            }
        }
        
    }
    void rotateRight()
    {
        for (int j = 0; j < rings.Count; j++)
        {
            
            if (rings[j].GetComponent<kaleidoRotate>().right == false)
            {
                groupRight = false;

                UnityEngine.Debug.Log("r1");
                return;
            }
            if(!groupDraging)
            groupRight = true;
        }
    }
}
