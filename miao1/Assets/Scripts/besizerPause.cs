using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class besizerPause : MonoBehaviour
{
    public GameObject pauseUI;
    public bool isPaused = false;
    public GameObject caozuoshuoming;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && BRhythmManager.instance.startPlaying)
        {
            //if Game is Paused, press Escape, Resume the Game
            if(!isPaused)
            {
                Pause();
            }

        }
    }
    public void Resume()
    {
        //inventoryMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;//Real time is 1.0f
        this.GetComponent<AudioSource>().UnPause();
        isPaused = false;
        pauseUI.SetActive(false);
        caozuoshuoming.SetActive(false);
    }

    public void Pause()
    {
        //inventoryMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;//STOP THE TIME
        this.GetComponent<AudioSource>().Pause();
        isPaused = true;
        pauseUI.SetActive(true);
    }
    public void backToMenu()
    {
        this.GetComponent<BChapterChoose>().chapterRecord[this.GetComponent<BChapterChoose>().chapter] = 0;
        this.GetComponent<besizerSceneReset>().resetScene();
        BRhythmManager.instance.resetPool();
        Resume();
    }
    public void showTip()
    {
        Pause();
        caozuoshuoming.SetActive(true);
    }
    public void exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void playAgain()
    {
        
        backToMenu();
        BRhythmManager.instance.resetPool();
        this.GetComponent<besizerSceneReset>().chooseObj.SetActive(false);
        BRhythmManager.instance.gameStart();
        Resume();
    }
}
