using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate2 : MonoBehaviour
{
    //public GameObject obj;
    public List<float> angles = new List<float>();
    public float f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator autoRotate()
    {
        for(int i=0; i<angles.Count; i++)
        {
            if(Mathf.Abs(this.transform.localEulerAngles.z - angles[i]) <= f)
            {
                var z = this.transform.localEulerAngles.z;
                //this.transform.Rotate(new Vector3(0, 0, (angles[i] - z)), )
            }
        }
        yield return new WaitForSeconds(0.2f);
    }
}
