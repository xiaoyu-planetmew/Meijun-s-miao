using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class acrossScene : MonoBehaviour
{
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();
        activeDialog();
    }
    public void activeDialog()
    {
        if(scene.name == "SampleScene")
        {
            GameObject.Find("NPCDialogBox").transform.GetChild(0).GetChild(0).GetComponent<Button>().onClick.Invoke();
            this.gameObject.SetActive(false);
        }
    }
}
