using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rotate2 : MonoBehaviour
{
    //public GameObject obj;
    public List<float> angles = new List<float>();
    //public List<Transform> highLight = new List<Transform>();
    public GameObject highLight0;
    public GameObject highLight1;
    public GameObject highLight2;
    public GameObject highLight3;
    //public GameObject highLight1;
    //public GameObject[] highLight = new GameObject[5];
    public float f;
    public float speed;
    //public List<Sprite>()
    // Start is called before the first frame update
    void Start()
    {
        //highLight = new List<Transform>();
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
        if((!angles.Contains(this.transform.localEulerAngles.z) && highLight0 != null))
        {
            Debug.Log("no");
            highLight0.SetActive(false);
            highLight1.SetActive(false);
            highLight2.SetActive(false);
            highLight3.SetActive(false);
        }
        if(highLight0 != null)
        {
            Debug.Log("rotate");
            //Debug.Log(highLights.Count);
        for(int j=0; j<angles.Count;j++)
        {
            
            if(this.transform.localEulerAngles.z == angles[j])
            {
                Debug.Log("rotate1");Debug.Log(j);
                if(j == 0)
                {
                    highLight0.SetActive(true);
                    highLight1.SetActive(false);
                    highLight2.SetActive(false);
                    highLight3.SetActive(false);
                }
                if(j == 1)
                {
                    highLight0.SetActive(false);
                    highLight1.SetActive(true);
                    highLight2.SetActive(false);
                    highLight3.SetActive(false);
                }
                if(j == 2)
                {
                    highLight0.SetActive(false);
                    highLight1.SetActive(false);
                    highLight2.SetActive(true);
                    highLight3.SetActive(false);
                }
                if(j == 3)
                {
                    highLight0.SetActive(false);
                    highLight1.SetActive(false);
                    highLight2.SetActive(false);
                    highLight3.SetActive(true);
                }
                if(j == 4)
                {
                    highLight0.SetActive(true);
                    highLight1.SetActive(false);
                    highLight2.SetActive(false);
                    highLight3.SetActive(false);
                }
                //highLights[j].gameObject.GetComponent<Image>().color = new Vector4(1, 1, 1, 1);
            }
        }
        
        }
    }
    
}
