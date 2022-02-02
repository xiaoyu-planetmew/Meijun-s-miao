using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class besizerSceneReset : MonoBehaviour
{
    public GameObject rhythmMa;
    public GameObject mainObj;
    public GameObject chooseObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetScene()
    {
        rhythmMa.GetComponent<BNoteGenerate>().enabled = false;
        rhythmMa.GetComponent<BRhythmManager>().combo = 0;
        rhythmMa.GetComponent<BRhythmManager>().currentScore = 0;
        rhythmMa.GetComponent<BRhythmManager>().currentNoteCount = 0;
        rhythmMa.GetComponent<BRhythmManager>().currentHitEffect = 0;
        rhythmMa.GetComponent<BRhythmManager>().accurary = 0;
        rhythmMa.GetComponent<BRhythmManager>().startPlaying = false;
        rhythmMa.GetComponent<BRhythmManager>().comboText.text = "0";
        //rhythmMa.GetComponent<BRhythmManager>().comboText.gameObject.SetActive(false);
        rhythmMa.GetComponent<BRhythmManager>().scoreText.text = "0";
        rhythmMa.GetComponent<BRhythmManager>().accuraryText.text = "0%";
        rhythmMa.GetComponent<BNoteGenerate>().saveList.Clear();
        rhythmMa.GetComponent<BNoteGenerate>().trackNum.Clear();
        rhythmMa.GetComponent<BNoteGenerate>().trackTime.Clear();
        rhythmMa.GetComponent<BNoteGenerate>().line.Clear();
        rhythmMa.GetComponent<BNoteGenerate>().usedNote.Clear();
        rhythmMa.GetComponent<BNoteGenerate>().saveListLong.Clear();
        rhythmMa.GetComponent<BNoteGenerate>().longTrackNum.Clear();
        rhythmMa.GetComponent<BNoteGenerate>().longLineList.Clear();    
        rhythmMa.GetComponent<BNoteGenerate>().longStartList.Clear();
        rhythmMa.GetComponent<BNoteGenerate>().longEndList.Clear();
        rhythmMa.GetComponent<BNoteGenerate>().usedLongNote.Clear();
        rhythmMa.GetComponent<AudioSource>().Stop();
        rhythmMa.GetComponent<BChapterChoose>().nowChapter.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = ((float)rhythmMa.GetComponent<BChapterChoose>().chapterRecord[rhythmMa.GetComponent<BChapterChoose>().chapter]).ToString("0.00%");
        foreach(GameObject obj in rhythmMa.GetComponent<BNoteGenerate>().aniList)
        {
            obj.SetActive(false);
        }
        mainObj.SetActive(false);
        chooseObj.SetActive(true);
    }
}
