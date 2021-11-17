using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class sceneCheck : MonoBehaviour
{
    public List<GameObject> scene0 = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene ();
        if(scene.name == "SampleScene")
        {
            foreach(var i in scene0)
            {
                i.gameObject.SetActive(true);
            }
        }else{
            foreach(var i in scene0)
            {
                i.gameObject.SetActive(false);
            }
        }
    }
}
