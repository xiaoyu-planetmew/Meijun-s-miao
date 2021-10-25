using UnityEngine;
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
    public TextAsset saveDate;
    public List<string> saveList = new List<string>();
    public List<float> trackTime = new List<float>();
    
    public List<int> line = new List<int>();
    public List<bool> usedNote;
    public float startTime;
    public float endTime;
    //public List<float> noteInterval = new List<float>();
    void Start()
    {
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
        saveList.Clear();
        var lineData = saveDate.text.Split('\n');
        foreach(var line in lineData)
        {
            saveList.Add(line);
        }
        for(int i = 0; i < lineData.Length - 1; i++)
        {
            var noteData = lineData[i].Split(',');
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
                    Debug.Log(bullet);
                    Debug.Log(i);
                    bullet.transform.position = startLocation.position;
                    bullet.GetComponent<DrawBesizerLine>().line = lineList[line[i] - 1].gameObject;
                    if(line[i] == 1 || line[i] == 4)
                    {
                        bullet.GetComponent<DrawBesizerLine>().speed = 124.6f;
                    }
                    if(!(line[i] == 1 || line[i] == 4))
                    {
                        bullet.GetComponent<DrawBesizerLine>().speed = 120f;
                    }
                    bullet.GetComponent<DrawBesizerLine>().enabled = true;
                    bullet.GetComponent<BNoteCanBeCount>().canBeCount = true;
                    bullet.GetComponent<DrawBesizerLine>().num = i; 
                }
                usedNote[i] = false;
                /*
                Debug.Log(i);
                Debug.Log(line[i]);
                Debug.Log(startLocation);
                Debug.Log(Time.time);
                */
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
}