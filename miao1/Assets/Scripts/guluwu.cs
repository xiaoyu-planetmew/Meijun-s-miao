using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guluwu : MonoBehaviour
{
    public float burnAniTime;
    private GameObject teleport;
    private GameObject thorn;
    private GameObject burn;
    public GameObject box;
    private bool burnt;
    // Start is called before the first frame update
    void Start()
    {
        teleport = this.transform.GetChild(1).transform.GetChild(0).gameObject;
        burn = this.transform.GetChild(1).transform.GetChild(1).gameObject;
        thorn = this.transform.GetChild(2).gameObject;
        burnt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.events[3] && !burnt)
        {
            burn.GetComponent<Button>().enabled = true;
        }
    }
    public void dialog()
    {

    }
    public void thornBurn()
    {
        StartCoroutine(burnAni());
        thorn.GetComponent<Animator>().SetTrigger("burn");
    }
    IEnumerator burnAni()
    {
        yield return new WaitForSeconds(burnAniTime);
        GameManager.instance.events[4] = true;
        teleport.SetActive(true);
        thorn.SetActive(false);
        this.gameObject.GetComponent<teleportButtonActive>().enabled = true;
        burnt = true;
    }
}
