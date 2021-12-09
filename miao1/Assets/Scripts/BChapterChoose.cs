using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BChapterChoose : MonoBehaviour
{
    public int chapterQuantity;
    public int chapter = 0;
    public int chapterDiffculty = 0;
    public List<Image> chapterTitle;
    public List<Image> chapterName;
    public List<string> chapterRecord;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chapterChange(int direction)
    {
        chapter += direction;
        if(chapter < 0)
        {
            chapter = chapterQuantity - 1;
        }
        if(chapter > chapterQuantity)
        {
            chapter = 0;
        }
    }
    public void diffcultChange(int diffculty)
    {
        chapterDiffculty = diffculty;
    }
    void changeAni(int direction)
    {

    }
}
