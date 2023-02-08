using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class bigBridgeEffect : MonoBehaviour
{
    public GameObject lLei1;
    public GameObject lLei2;
    public GameObject rLei1;
    public GameObject rLei2;
    public GameObject sun;
    public List<GameObject> cloud = new List<GameObject>();
    public List<Vector2> lei1pos = new List<Vector2>();
    public List<Vector2> lei2pos = new List<Vector2>();
    public List<Vector2> lei3pos = new List<Vector2>();
    public List<Vector2> lei4pos = new List<Vector2>();
    float time = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        lLei1.SetActive(false);
        lLei2.SetActive(false);
        rLei1.SetActive(false);
        lLei2.SetActive(false);
        foreach(var obj in cloud)
        {
            obj.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            obj.GetComponent<Image>().DOFade(1f, 2f);
        }
        sun.GetComponent<SpriteRenderer>().DOFade(0, 1f);
        //StartCoroutine(lLei());
        //StartCoroutine(rLei());
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time<=0)
        {
            randomThunder();
        }
    }
    void randomThunder()
    {
        //Sprite s;
        int r1 = Random.Range(0, 4);
        if(r1 == 0)
        {
            int r2 = Random.Range(0, lei1pos.Count);
            lLei1.GetComponent<RectTransform>().anchoredPosition = lei1pos[r2];
            thunderAnim(lLei1);
        }
        if(r1 == 1)
        {
            int r2 = Random.Range(0, lei2pos.Count);
            lLei2.GetComponent<RectTransform>().anchoredPosition = lei2pos[r2];
            thunderAnim(lLei2);
        }
        if(r1 == 2)
        {
            int r2 = Random.Range(0, lei3pos.Count);
            rLei1.GetComponent<RectTransform>().anchoredPosition = lei3pos[r2];
            thunderAnim(rLei1);
        }
        if(r1 == 3)
        {
            int r2 = Random.Range(0, lei4pos.Count);
            rLei2.GetComponent<RectTransform>().anchoredPosition = lei4pos[r2];
            thunderAnim(rLei2);
        }
    }
    void thunderAnim(GameObject obj)
    {
        obj.SetActive(true);
        obj.GetComponent<Image>().color = new Color32(255, 255, 255, 127);
        GameObject.Find("CamaraFocus").GetComponent<CamaraFocusFollow>().camShake();
        Sequence quence = DOTween.Sequence();
        quence.Append(obj.GetComponent<Image>().DOFade(1, 0.1f));
        quence.Append(obj.GetComponent<Image>().DOFade(0.5f, 0.15f));
        quence.Append(obj.GetComponent<Image>().DOFade(0f, 2f)).OnComplete(() => {
            obj.SetActive(false);
        });
        time = Random.Range(1f, 4f);
    }
    public void thunderStop()
    {
        time = 999f;
        foreach(var obj in cloud)
        {
            obj.GetComponent<Image>().DOFade(0, 2f);
        }
        sun.GetComponent<SpriteRenderer>().DOFade(1, 1f).OnComplete(() => {
            this.gameObject.SetActive(false);
        });
    }
}
