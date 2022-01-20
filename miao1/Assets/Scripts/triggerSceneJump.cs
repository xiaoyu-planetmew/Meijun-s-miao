using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class triggerSceneJump : MonoBehaviour
{
    public int jumpToSceneNum;
    public int currentSceneNum;
    //public float jumpDistance;
    public List<GameObject> cameras = new List<GameObject>();
    //public GameObject player;
    //public GameObject button;
   
    public List<GameObject> locations = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Mathf.Abs(transform.position.x - GameManager.instance.player.transform.position.x) < jumpDistance)
        {
            button.SetActive(true);
        }
        if(Mathf.Abs(transform.position.x - GameManager.instance.player.transform.position.x) > jumpDistance)
        {
            button.SetActive(false);
        }*/
        //SceneManager.MoveGameObjectToScene(GameManager.instance.player, sceneNum);
        
    }
    public void teleport()
    {
        if(currentSceneNum == 0)
        {
            if(jumpToSceneNum == 1)
            {
                GameManager.instance.player.transform.position = locations[1].transform.position;
                cameras[0].SetActive(false);
                cameras[1].SetActive(true);
            }
        }
        if(currentSceneNum == 1)
        {
            if(jumpToSceneNum == 0)
            {
                GameManager.instance.player.transform.position = locations[0].transform.position;
                cameras[0].SetActive(true);
                cameras[1].SetActive(false);
            }
            if(jumpToSceneNum == 2)
            {
                GameManager.instance.player.transform.position = locations[3].transform.position;
                cameras[2].SetActive(true);
                cameras[1].SetActive(false);
            }
            if(jumpToSceneNum == 3)
            {
                GameManager.instance.player.transform.position = locations[5].transform.position;
                cameras[3].SetActive(true);
                cameras[1].SetActive(false);
            }
        }
        if(currentSceneNum == 2)
        {
            GameManager.instance.player.transform.position = locations[2].transform.position;
            cameras[1].SetActive(true);
            cameras[2].SetActive(false);
        }
        if(currentSceneNum == 3)
        {
            if(jumpToSceneNum == 1)
            {
                GameManager.instance.player.transform.position = locations[2].transform.position;
                cameras[1].SetActive(true);
                cameras[3].SetActive(false);
            }
            if(jumpToSceneNum == 4)
            {
                GameManager.instance.player.transform.position = locations[6].transform.position;
                cameras[4].SetActive(true);
                cameras[3].SetActive(false);
            }
        }
        if(currentSceneNum == 4)
        {
            Debug.Log(currentSceneNum);
            GameManager.instance.player.transform.position = locations[4].transform.position;
            cameras[3].SetActive(true);
            cameras[4].SetActive(false);

        }
        Debug.Log(currentSceneNum);
    }
}
