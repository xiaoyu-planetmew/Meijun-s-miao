using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneCheck2 : MonoBehaviour
{
    public List<GameObject> scene0 = new List<GameObject>();
    public bool final = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!final)
        {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Scene2")
            {
                foreach (var i in scene0)
                {
                    i.gameObject.SetActive(true);
                }
            }
            else
            {
                foreach (var i in scene0)
                {
                    i.gameObject.SetActive(false);
                }
            }
        }
    }
}
