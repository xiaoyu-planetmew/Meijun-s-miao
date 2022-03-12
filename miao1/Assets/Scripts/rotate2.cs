using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate2 : MonoBehaviour
{
    //public GameObject obj;
    public List<float> angles = new List<float>();
    public float f;
    public float speed;
    //public List<Sprite>()
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.eulerAngles);
        
        for(int i=0; i<angles.Count; i++)
        {
            //Debug.Log(i);
            //Debug.Log((Mathf.Abs(this.transform.localEulerAngles.z - angles[i])));
            if(Mathf.Abs(this.transform.localEulerAngles.z - angles[i]) < f && !this.GetComponent<rotate>().draging)
            {
                var z = this.transform.localEulerAngles.z;
                //Debug.Log(angles[i]);
                this.transform.eulerAngles = Vector3.MoveTowards(this.transform.eulerAngles, new Vector3(0, 0, angles[i]), Time.deltaTime * speed);
            }
        }
    }
    
}
