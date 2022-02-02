using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BArtLetter : MonoBehaviour
{
    public List<GameObject> letters = new List<GameObject>();
    public List<Sprite> Numbers = new List<Sprite>();
    [SerializeField] private int combo;
    public float interval;
    private float XInitial;
    private float YInitial;
    [SerializeField] private int num;
   
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform l in this.transform)
        {
            letters.Add(l.gameObject);
        }
        for(int i = 0; i < letters.Count; i++)
        {
            letters[i].transform.localPosition = new Vector3(interval * (-1) * i, 0, 0);
        }
        XInitial = this.transform.position.x;
        YInitial = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        combo = BRhythmManager.instance.combo;
        UpdateShowLetters();
    }
    

    /// <summary>
    /// 更新显示的数字
    /// </summary>
    void UpdateShowLetters()
    {
        var l = combo.ToString();
        num = l.Length;
        if(num == 1)
        {
            letters[0].transform.localPosition = new Vector3(0, 0, 0);
        }
        if(num == 2)
        {
            letters[0].transform.localPosition = new Vector3((interval) * 0.5f, 0, 0);
            letters[1].transform.localPosition = new Vector3((interval) * -0.5f, 0, 0);
        }
        if(num == 3)
        {
            letters[0].transform.localPosition = new Vector3((interval), 0, 0);
            letters[1].transform.localPosition = new Vector3(0, 0, 0);
            letters[2].transform.localPosition = new Vector3((interval) * (-1), 0, 0);
        }
        if(num == 4)
        {
            letters[0].transform.localPosition = new Vector3((interval) * 1.5f, 0, 0);
            letters[1].transform.localPosition = new Vector3((interval) * 0.5f, 0, 0);
            letters[2].transform.localPosition = new Vector3((interval) * -0.5f, 0, 0);
            letters[3].transform.localPosition = new Vector3((interval) * -1.5f, 0, 0);
        }
        if(combo <= 4)
        {
            for(int i = 0; i < letters.Count; i++)
            {
                letters[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if(combo > 4)
        {
            for (int i = 0; i < num; i++)
            {
                letters[i].GetComponent<SpriteRenderer>().enabled = true;
                letters[i].GetComponent<SpriteRenderer>().sprite = Numbers[Mathf.FloorToInt((combo / Mathf.Pow(10, i))) % 10];
            }
            if(num != 4)
            {
                for(int i = 3; i >= num; i--)
                {
                    letters[i].GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
    }
}
