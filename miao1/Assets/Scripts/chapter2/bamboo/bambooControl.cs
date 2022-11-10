using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class bambooControl : MonoBehaviour
{
    public GameObject beijingtu;
    public GameObject bambooAudio;
    public List<AudioClip> bambooVoices = new List<AudioClip>();
    public List<Sprite> patternLight = new List<Sprite>();
    public List<Sprite> patternDark = new List<Sprite>();
    public List<GameObject> tips = new List<GameObject>();
    
    public List<Image> lights = new List<Image>();
    public List<int> lines = new List<int>();
    public List<int> lineCounts = new List<int>();
    public int[] nowLine = new int[5];
    public bool bool0;
    public bool bool1;
    public bool bool2;
    public int nowNote;
    public int nowLineNumber;
    // Start is called before the first frame update
    void Start()
    {
        newLine(0);
        nowLineNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void newLine(int l)
    {
        nowLine[0] = 0;
        nowLine[1] = 0;
        nowLine[2] = 0;
        nowLine[3] = 0;
        nowLine[4] = 0;
        bool0 = false;
        bool1 = false;
        bool2 = false;
        for(int i=0; i<3; i++)
        {
            lights[i].color = new Vector4(1, 1, 1, 0);
        }
        nowNote = 0;
        nowLine[4] = lines[l] % 10;
        nowLine[3] = lines[l] / 10 % 10;
        nowLine[2] = lines[l] / 100 % 10;
        nowLine[1] = lines[l] / 1000 % 10;
        nowLine[0] = lines[l] / 10000 % 10;
        for(int i=0; i<5; i++)
        {
            tips[i].GetComponent<Image>().sprite = patternDark[nowLine[i]];
            tips[i].GetComponent<RectTransform>().sizeDelta = new Vector2(patternDark[nowLine[i]].textureRect.width, patternDark[nowLine[i]].textureRect.height);
        }
        for(int i=0; i<5-lineCounts[l]; i++)
        {
            tips[i].GetComponent<Image>().enabled = false;
        }
        for(int i= 5 - lineCounts[l]; i<5; i++)
        {
            tips[i].GetComponent<Image>().enabled = true;
        }
        if(lineCounts[l] == 3)
        {
            tips[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-432, 432, 0);
            tips[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 432, 0);
            tips[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(432, 432, 0);
        }
        if (lineCounts[l] == 4)
        {
            tips[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-432, 432, 0);
            tips[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-144, 432, 0);
            tips[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(144, 432, 0);
            tips[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(432, 432, 0);
        }
        if (lineCounts[l] == 5)
        {
            tips[0].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-432, 432, 0);
            tips[1].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-216, 432, 0);
            tips[2].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 432, 0);
            tips[3].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(216, 432, 0);
            tips[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(432, 432, 0);
        }
        newDelay();
    }
    public void inputLine(int pos)
    {
        Debug.Log(nowLine[nowNote + 5 - lineCounts[nowLineNumber]]);
        Debug.Log(pos);
        lights[pos].color = new Vector4(1, 1, 1, 1);
        if (nowLine[nowNote + 5 - lineCounts[nowLineNumber]] == pos)
        {
            tips[nowNote + 5 - lineCounts[nowLineNumber]].GetComponent<Image>().sprite = patternLight[nowLine[nowNote + 5 - lineCounts[nowLineNumber]]];
            tips[nowNote + 5 - lineCounts[nowLineNumber]].GetComponent<RectTransform>().sizeDelta = new Vector2(patternLight[nowLine[nowNote + 5 - lineCounts[nowLineNumber]]].textureRect.width, patternLight[nowLine[nowNote + 5 - lineCounts[nowLineNumber]]].textureRect.height);
            nowNote++;
            playAudio(pos);
            turnButtons(false);
            DG.Tweening.Sequence quence = DOTween.Sequence();
            if (pos == 0)
            {
                quence.Append(beijingtu.transform.DOLocalRotate(new Vector3(0, 0, -3), 0.1f));
                quence.Append(beijingtu.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f)).OnComplete(() =>
                {
                    turnButtons(true);
                    for(int i=0; i<3; i++)
                    {
                        lights[i].color = new Vector4(1, 1, 1, 0);
                    }
                    if (nowNote + 5 - lineCounts[nowLineNumber] > 4)
                    {
                        succeedLine(nowLineNumber);
                    }
                });
            }
            if (pos == 1)
            {
                //quence.Append(beijingtu.transform.DOMove(new Vector3(0, 1, 0), 0.1f));
                quence.Append(beijingtu.transform.DOShakePosition(0.2f, new Vector3(0, 50, 0), 1, 0, true)).OnComplete(() =>
                {
                    turnButtons(true);
                    for (int i = 0; i < 3; i++)
                    {
                        lights[i].color = new Vector4(1, 1, 1, 0);
                    }
                    if (nowNote + 5 - lineCounts[nowLineNumber] > 4)
                    {
                        succeedLine(nowLineNumber);
                    }
                });
            }
            if (pos == 2)
            {
                quence.Append(beijingtu.transform.DOLocalRotate(new Vector3(0, 0, 3), 0.1f));
                quence.Append(beijingtu.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.1f)).OnComplete(() =>
                {
                    turnButtons(true);
                    for (int i = 0; i < 3; i++)
                    {
                        lights[i].color = new Vector4(1, 1, 1, 0);
                    }
                    if (nowNote + 5 - lineCounts[nowLineNumber] > 4)
                    {
                        succeedLine(nowLineNumber);
                    }
                });
            }

            
        }
        else
        {
            wrongNote(nowLineNumber);
        }
    }
    void turnButtons(bool b)
    {
        for(int i=0; i<3; i++)
        {
            lights[i].gameObject.GetComponent<Button>().enabled = b;
            //lights[i].color = new Vector4(1, 1, 1, 0);
        }
    }
    void newDelay()
    {
        turnButtons(false);
        DG.Tweening.Sequence quence = DOTween.Sequence();
        quence.AppendInterval(1);
        for (int i=0; i<lineCounts[nowLineNumber]; i++)
        {
            var j = 5 - lineCounts[nowLineNumber] + i;
            quence.Append(lights[nowLine[j]].DOFade(0.8f, 0.1f).OnStart(() => {
                playAudio(nowLine[j]);
            }));
            quence.AppendInterval(1);
            quence.Append(lights[nowLine[j]].DOFade(0, 0.1f));
        }
        quence.AppendInterval(0.2f).OnComplete(() => {
            turnButtons(true);
        });
    }
    public void wrongNote(int l)
    {
        Debug.Log("wrong");
        StartCoroutine(wrongDelay());
        turnButtons(false);
        DG.Tweening.Sequence quence = DOTween.Sequence();
        //quence.AppendInterval(1);
        quence.Append(beijingtu.transform.DOShakePosition(1, new Vector3(20, 0, 0), 10, 50, true)).OnComplete(() => 
        {
            turnButtons(true);
            nowLineNumber++;
            if (nowLineNumber >= lines.Count)
            {
                Debug.Log("finish");
            }
            else
                newLine(nowLineNumber);
        });
    }
    IEnumerator wrongDelay()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 3; i++)
        {
            //lights[i].gameObject.GetComponent<Button>().enabled = b;
            lights[i].color = new Vector4(1, 1, 1, 0);
        }
    }
    public void succeedLine(int l)
    {
        Debug.Log("success");
        nowLineNumber++;
        if (nowLineNumber >= lines.Count)
        {
            Debug.Log("finish");
        }else
        newLine(nowLineNumber);
    }
    public void playAudio(int pos)
    {
        bambooAudio.GetComponent<AudioSource>().Stop();
        bambooAudio.GetComponent<AudioSource>().clip = bambooVoices[pos];
        bambooAudio.GetComponent<AudioSource>().Play();
    }
}
