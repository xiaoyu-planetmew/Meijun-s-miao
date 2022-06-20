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
    }
}
