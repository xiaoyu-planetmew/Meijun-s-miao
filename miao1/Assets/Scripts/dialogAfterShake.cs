using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogAfterShake : MonoBehaviour
{
    bool shaked = false;
    public GameObject wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void shake()
    {
        if(!shaked)
        {
            GameObject.Find("Main Camera").GetComponent<cameraShake>().isShakingCamera = true;
            wall.SetActive(false);
            shaked = true;
            
        }
    }
}
