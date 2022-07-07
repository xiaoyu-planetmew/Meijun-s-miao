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
        
    }
    void rotateStop()
    {
        for(int i=0; i<rings.Count; i++)
        {
            if(rings[i].GetComponent<kaleidoRotate>().draging = true)
            {
                return;
                Debug.Log("r1");
            }
            
            
            if((rings[i].transform.localEulerAngles.z > 5 || rings[i].transform.localEulerAngles.z < 355))
            {
                return;
                Debug.Log("r2");
            }
            Debug.Log("r3");
            rings[i].transform.eulerAngles = Vector3.MoveTowards(rings[i].transform.eulerAngles, new Vector3(0, 0, 0), Time.deltaTime * speed); 
        }
    }
}
