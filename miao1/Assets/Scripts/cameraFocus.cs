using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Spine.Unity;

public class cameraFocus : MonoBehaviour
{
    public Transform focusLocation;
    public GameObject focusCanvas;
    public GameObject npc;
    public GameObject dialogBox;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void focus()
    {
        this.GetComponent<CinemachineBrain>().enabled = false;
        focusCanvas.transform.GetChild(0).gameObject.SetActive(true);
        GameManager.instance.player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("disappear");
        GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = false;
        StartCoroutine(ani());
        StartCoroutine(MoveToPosition());
        dialogBox.transform.GetChild(2).gameObject.GetComponent<Image>().enabled = false;
        
    }
    public void cancelFocus()
    {
       this.GetComponent<CinemachineBrain>().enabled = true;
       focusCanvas.transform.GetChild(0).gameObject.SetActive(false);
       GameManager.instance.player.transform.GetChild(0).GetComponent<Animator>().SetTrigger("appear");
       GameObject.Find("InventoryCanvas").gameObject.GetComponent<Canvas>().enabled = true;
       npc.transform.GetChild(1).GetComponent<AudioSource>().Stop();
       npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "widle", true);
    }
    
    IEnumerator MoveToPosition()
    {     
        while (gameObject.transform.position != focusLocation.position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, focusLocation.position, speed * Time.deltaTime);
            yield return 0;
        }
        StartCoroutine(colorChange());
    }
    IEnumerator colorChange()
    {
        while(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a < 1)
        {
            focusCanvas.transform.GetChild(0).GetComponent<Image>().color = new Color(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.r, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.g, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.b, focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a+0.01f);
            //Debug.Log(focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a);
            //GameObject.Find("")
            yield return 0;
        }
    }
    IEnumerator ani()
    {
        yield return new WaitUntil(() => focusCanvas.transform.GetChild(0).GetComponent<Image>().color.a >= 1);  
        //Debug.Log("1");
        npc.transform.GetChild(1).GetComponent<AudioSource>().Play();
        npc.transform.GetChild(0).GetComponent<SkeletonAnimation>().state.SetAnimation(0, "wdance", true);
        dialogBox.transform.GetChild(2).gameObject.GetComponent<Button>().onClick.Invoke();
        dialogBox.transform.GetChild(2).gameObject.GetComponent<Image>().enabled = true;
    }
}
