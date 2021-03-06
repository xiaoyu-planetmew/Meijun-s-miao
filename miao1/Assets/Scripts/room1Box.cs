using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room1Box : MonoBehaviour
{
    public GameObject plant1;
    public GameObject plant2;
    public GameObject plant3;
    public GameObject paper;
    public List<GameObject> boxPart = new List<GameObject>();
    public GameObject textTip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void open()
    {
        textTip.SetActive(false);
        StopAllCoroutines();
        if((plant1.transform.localEulerAngles.z == 90) && (plant2.transform.localEulerAngles.z == 0) && (plant3.transform.localEulerAngles.z == 270f))
        {
            //Debug.Log("open");
            paper.SetActive(true);
            foreach(var obj in boxPart)
            {
                obj.SetActive(false);
            }
        }else{
            textTip.SetActive(true);
            StartCoroutine(textShow());
            //Debug.Log(plant1.transform.localEulerAngles.z);
            //Debug.Log(plant2.transform.localEulerAngles.z);
            //Debug.Log(plant3.transform.localEulerAngles.z);
        }
    }
    public void showBox()
    {
        GameObject.Find("shinei01").transform.Find("Canvas").gameObject.SetActive(false);
    }
    public void hideBox()
    {
        GameObject.Find("shinei01").transform.Find("Canvas").gameObject.SetActive(true);
        GameManager.instance.player.GetComponent<FinalMovement>().continueMoving();
    }
    IEnumerator textShow()
    {
        yield return new WaitForSeconds(2f);
        textTip.SetActive(false);
    }
}
