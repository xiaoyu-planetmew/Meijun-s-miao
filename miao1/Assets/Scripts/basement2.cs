using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basement2 : MonoBehaviour
{
    public GameObject _item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((this.transform.GetChild(2).localEulerAngles.z == 0) && (this.transform.GetChild(3).localEulerAngles.z == 0) && (this.transform.GetChild(4).localEulerAngles.z == 0))
        {
            _item.SetActive(true);
            this.transform.GetChild(2).gameObject.GetComponent<rotate>().enabled = false;
            this.transform.GetChild(2).gameObject.GetComponent<rotate2>().enabled = false;
            this.transform.GetChild(3).gameObject.GetComponent<rotate>().enabled = false;
            this.transform.GetChild(3).gameObject.GetComponent<rotate2>().enabled = false;
            this.transform.GetChild(4).gameObject.GetComponent<rotate>().enabled = false;
            this.transform.GetChild(4).gameObject.GetComponent<rotate2>().enabled = false;
        }
    }
}
