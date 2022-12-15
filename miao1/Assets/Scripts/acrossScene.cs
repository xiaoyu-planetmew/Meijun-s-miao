using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class acrossScene : MonoBehaviour
{
    Scene scene;
    public Button npcButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() 
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
        if (scene.name == "Scene2")
        {
            npcButton.gameObject.SetActive(true);
            npcButton.onClick.Invoke();
            StartCoroutine(scene2Delay());
            
            //this.transform.parent.transform.Find("Save").transform.Find("Npc").transform.Find("JiangSongCanvas").Find("startButton").GetComponent<Button>().onClick.Invoke();
            //GameObject.Find("GameManager2").transform.Find("Save").transform.Find("Npc").transform.Find("JiangSongCanvas").Find("startButton").GetComponent<Button>().onClick.Invoke();
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator scene2Delay()
    {
        yield return new WaitForSeconds(2f);
        npcButton.gameObject.SetActive(true);
        npcButton.onClick.Invoke();
    }
}
