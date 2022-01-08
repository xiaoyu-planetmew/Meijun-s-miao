using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Kernal;

public class rotateStop : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public List<float> stopAngle = new List<float>();
    public List<bool> rotateSuc;
    public float range;
    [SerializeField] bool suc = false;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<objects.Count; i++)
        {
            rotateSuc.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<objects.Count; i++)
        {
            Debug.Log(objects[0].transform.localEulerAngles.z);
            if(Mathf.Abs((objects[i].transform.localEulerAngles.z - stopAngle[i])) <= range)
            rotateSuc[i] = true;
        }
        if(!rotateSuc.Contains(false))
        {
            suc = true;
            for(int j=0; j<objects.Count; j++)
            {
                objects[j].GetComponent<rotate>().canBeDrag = false;
                objects[j].transform.localEulerAngles = new Vector3(0f, 0f, stopAngle[j]);
            }
        }
        
    }
}
