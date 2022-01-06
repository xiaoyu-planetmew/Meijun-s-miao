using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BNoteGenerate : MonoBehaviour
{
    //传统创建子弹方法需要的子弹perfabs
    //public GameObject shotObj;

    //public GameObject shotSpawn;                //子弹发射的初始化位置

    //public float fireRate = 0.2f;               //每次发射子弹事件间隔

    //private float nextFire;                     //下一次发射子弹的时间
    
    public GameObject lines;
    
    public List<Transform> lineList;
    public List<AudioClip> musicList = new List<AudioClip>();
    public List<float> delayTimeList = new List<float>();
    public List<float> songTimeList = new List<float>();
    
    public List<Sprite> titleList = new List<Sprite>();
    public GameObject title;
    public List<Sprite> bgList = new List<Sprite>();
    public GameObject bg;
    public List<GameObject> aniList = new List<GameObject>();
    public List<TextAsset> saveDates = new List<TextAsset>();
    public TextAsset saveDate;
    public List<string> saveList = new List<string>();
    public List<float> trackNum = new List<float>();
    public List<float> trackTime = new List<float>();
    
    public List<int> line = new List<int>();
    public List<bool> usedNote;
    public List<TextAsset> saveDatesLong = new List<TextAsset>();
    public TextAsset saveDateLong;
    public List<string> saveListLong = new List<string>();
    public List<float> longTrackNum = new List<float>();
    public List<float> longStartList = new List<float>();
    public List<float> longEndList = new List<float>();
    public List<int> longLineList = new List<int>();
    public List<bool> usedLongNote;
    public Material mat;
    
    private float startTime;
    private float endTime;
    //public List<float> noteInterval = new List<float>();
    void Start()
    {
        /*
        if(GameManager.instance.mail == "m1easy" || GameManager.instance.mail == "m2easy")
        {
            saveDate = saveDates[1];
        }
        if(GameManager.instance.mail == "m1hard" || GameManager.instance.mail == "m2hard")
        {
            saveDate = saveDates[0];
        }
        */
        saveDate = saveDates[this.gameObject.GetComponent<BChapterChoose>().chapter * 2 + this.gameObject.GetComponent<BChapterChoose>().chapterDiffculty];
        saveDateLong = saveDatesLong[this.gameObject.GetComponent<BChapterChoose>().chapter * 2 + this.gameObject.GetComponent<BChapterChoose>().chapterDiffculty];
        this.GetComponent<AudioSource>().clip = musicList[this.gameObject.GetComponent<BChapterChoose>().chapter];
        //aniList[this.gameObject.GetComponent<BChapterChoose>().chapter * 2].SetActive(true);
        //aniList[this.gameObject.GetComponent<BChapterChoose>().chapter * 2 + 1].SetActive(true);
        title.gameObject.GetComponent<Image>().sprite = titleList[this.gameObject.GetComponent<BChapterChoose>().chapter];
        bg.gameObject.GetComponent<SpriteRenderer>().sprite = bgList[this.gameObject.GetComponent<BChapterChoose>().chapter];
        //this.GetComponent<BRhythmManager>().delayTime = delayTimeList[this.gameObject.GetComponent<BChapterChoose>().chapter];
        //this.GetComponent<BRhythmManager>().songTime = songTimeList[this.gameObject.GetComponent<BChapterChoose>().chapter];
        startTime = Time.time;
        lineList = new List<Transform>();
        
        usedNote = new List<bool>();
        foreach(Transform child in lines.transform)
        {
            //Debug.Log(child.gameObject.name);
            lineList.Add(child);
            //basePoint[i] = line.transform.GetChild(i).gameObject;
        }
        readFromTXT();
        readFormTXTLong();
        for(int i = 0; i < trackTime.Count; i++)
        {
            usedNote.Add(true);
            trackTime[i] = trackTime[i];
        }
        /*
        noteInterval[0] = trackTime[0];
        for(int i = 0; i < trackTime.Count - 1; i++)
        {
            noteInterval[i + 1] = trackTime[i + 1] - trackTime[i];
        }
        */
    }
    void readFromTXT()
    {
        trackNum.Clear();
        trackTime.Clear();
        line.Clear();
        saveList.Clear();
        var lineData = saveDate.text.Split('\n');
        foreach(var line in lineData)
        {
            saveList.Add(line);
            
        }
        for(int i = 0; i < lineData.Length - 1; i++)
        {
            var noteData = lineData[i].Split(',');
            trackNum.Add(float.Parse(noteData[0]));
            trackTime.Add(float.Parse(noteData[1]));
            if(noteData[2] == "S")
            {
                line.Add(1);
            }
            if(noteData[2] == "D")
            {
                line.Add(2);
            }
            if(noteData[2] == "F")
            {
                line.Add(3);
            }
            if(noteData[2] == "J")
            {
                line.Add(4);
            }
            if(noteData[2] == "K")
            {
                line.Add(5);
            }
            if(noteData[2] == "L")
            {
                line.Add(6);
            }

        }
    }
    void readFormTXTLong()
    {
        longTrackNum.Clear();
        longStartList.Clear();
        longEndList.Clear();
        longLineList.Clear();
        saveListLong.Clear();
        usedLongNote.Clear();
        var lineData = saveDateLong.text.Split('\n');
        foreach(var line in lineData)
        {
            saveListLong.Add(line);
            
        }
        for(int i = 0; i < lineData.Length - 1; i++)
        {
            var noteData = lineData[i].Split(',');
            longTrackNum.Add(float.Parse(noteData[0]));
            longStartList.Add(float.Parse(noteData[1]));
            longEndList.Add(float.Parse(noteData[2]));
            //longLineList.Add(int.Parse(noteData[3]));
            usedLongNote.Add(true);
            
            if(noteData[3] == "S")
            {
                longLineList.Add(1);
            }
            if(noteData[3] == "D")
            {
                longLineList.Add(2);
            }
            if(noteData[3] == "F")
            {
                longLineList.Add(3);
            }
            if(noteData[3] == "J")
            {
                longLineList.Add(4);
            }
            if(noteData[3] == "K")
            {
                longLineList.Add(5);
            }
            if(noteData[3] == "L")
            {
                longLineList.Add(6);
            }
            
        }
    }
    void FixedUpdate()
    {
        for(int i = 0; i < trackTime.Count; i++)
        {
            if(Time.time - startTime > trackTime[i] && usedNote[i] == true)
            {
                GameObject bullet = BRhythmManager.instance.GetPooledObject();
                
                Transform startLocation = lineList[line[i] - 1].GetChild(0);
                if(bullet != null)                  //不为空时执行
                {
                    bullet.SetActive(true);        //激活子弹并初始化子弹的位置
                    //Debug.Log(bullet);
                    //Debug.Log(i);
                    bullet.transform.position = startLocation.position;
                    bullet.GetComponent<DrawBesizerLine>().line = lineList[line[i] - 1].gameObject;
                    if(line[i] == 1 || line[i] == 4)
                    {
                        bullet.GetComponent<DrawBesizerLine>().speed = 62.3f;
                    }
                    if(!(line[i] == 1 || line[i] == 4))
                    {
                        bullet.GetComponent<DrawBesizerLine>().speed = 60f;
                    }
                    bullet.GetComponent<DrawBesizerLine>().baseCount = 25;
                    bullet.GetComponent<DrawBesizerLine>().enabled = true;
                    bullet.GetComponent<BNoteCanBeCount>().canBeCount = true;
                    bullet.GetComponent<DrawBesizerLine>().num = trackNum[i];
                    bullet.GetComponent<DrawBesizerLine>().numInSequence = i;
                    if(i == 0)
                    {
                        bullet.GetComponent<DrawBesizerLine>().numInSequence++;
                    }
                    bullet.GetComponent<BNoteCanBeCount>().line = line[i];
                    //bullet.transform.GetChild(0).GetComponent<TrailRenderer>().time = -1;
                    //StartCoroutine(trailReset(bullet.transform.GetChild(0).gameObject));
                }
                usedNote[i] = false;                
            }
        }
        for(int i = 0; i < longLineList.Count; i++)
        {
            if(Time.time - startTime > longStartList[i] && usedLongNote[i] == true)
            {
                GameObject bullet = BRhythmManager.instance.GetLongPooledObject();
                
                Transform startLocation = lineList[longLineList[i] - 1].GetChild(0);
                if(bullet != null)                  //不为空时执行
                {
                    bullet.SetActive(true);        //激活子弹并初始化子弹的位置
                    //Debug.Log(bullet);
                    //Debug.Log(i);
                    bullet.transform.position = startLocation.position;
                    bullet.GetComponent<DrawBesizerLine>().line = lineList[longLineList[i] - 1].gameObject;
                    if(longLineList[i] == 1 || longLineList[i] == 4)
                    {
                        bullet.GetComponent<DrawBesizerLine>().speed = 62.3f;
                    }
                    if(!(longLineList[i] == 1 || longLineList[i] == 4))
                    {
                        bullet.GetComponent<DrawBesizerLine>().speed = 60f;
                    }
                    bullet.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = true;
                    bullet.GetComponent<DrawBesizerLine>().baseCount = 25;
                    bullet.GetComponent<DrawBesizerLine>().enabled = true;
                    bullet.GetComponent<BNoteCanBeCount>().line = longLineList[i];
                    bullet.GetComponent<BNoteCanBeCount>().canBeCount = true;
                    bullet.GetComponent<DrawBesizerLine>().num = -1; 
                    bullet.GetComponent<DrawBesizerLine>().numInSequence = 1;
                    bullet.transform.GetChild(0).GetComponent<TrailRenderer>().time = -1;
                    bullet.transform.GetChild(0).GetComponent<TrailRenderer>().material= mat;
                    StartCoroutine(trailReset(bullet.transform.GetChild(0).gameObject, longEndList[i] - longStartList[i]));
                }
                usedLongNote[i] = false;                
            }
        }
        //if(Time.time - startTime > endTime + 1)
        //{
            
        //}
        /*
        if (Time.time > nextFire)               //可以发射子弹时间
        {
            nextFire = Time.time + fireRate;

            //传统创建子弹方法
            //Instantiate(shotObj, shotSpawn.transform.position, shotSpawn.transform.rotation);

            //获取对象池中的子弹
            GameObject bullet = BRhythmManager.instance.GetPooledObject();
            if(bullet != null)                  //不为空时执行
            {
                bullet.SetActive(true);         //激活子弹并初始化子弹的位置
                bullet.transform.position = shotSpawn.transform.position;
                bullet.GetComponent<DrawBesizerLine>().line = line1;
            }
        }
        */
    }
    IEnumerator trailReset(GameObject obj, float noteLength)
    {
        yield return new WaitForSeconds(0.1f);
        obj.GetComponent<TrailRenderer>().time = noteLength;
    }
}