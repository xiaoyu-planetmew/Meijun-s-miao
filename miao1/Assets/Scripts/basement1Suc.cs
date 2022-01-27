using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basement1Suc : MonoBehaviour
{
    //public GameObject basement1Door;
    public GameObject keyStone;
    public GameObject key;
    public Camera cam;
    bool shaked= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<roomCamera>().cam != null)
        {
            cam = this.GetComponent<roomCamera>().cam.GetComponent<Camera>();
        }
        if(inventoryResponse.instance.usefulItem.Count== 0)
        {
            this.transform.GetChild(3).gameObject.SetActive(true);
            this.transform.GetChild(4).gameObject.SetActive(true);
            this.transform.GetChild(5).gameObject.SetActive(true);
        }
        if(this.transform.GetChild(3).gameObject.GetComponent<basement1>().rightSeed 
        && this.transform.GetChild(4).gameObject.GetComponent<basement1>().rightSeed 
        && this.transform.GetChild(5).gameObject.GetComponent<basement1>().rightSeed && !shaked)
        {
            cam.gameObject.GetComponent<cameraShake>().isShakingCamera = true;
            shaked = true;
            StartCoroutine(keyDisplay());
        } 
    }
    IEnumerator keyDisplay()
    {
        yield return new WaitForSeconds(2f);
        keyStone.SetActive(true);
        key.SetActive(true);
        cam.gameObject.GetComponent<cameraShake>().isShakingCamera = false;
        //basement1Door.SetActive(true);
    }
    
}
