using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startMenuStartButton : MonoBehaviour
{
    public int languageNum;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void startButton2()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void languageSelectButton(int num)
    {
        //SceneManager.LoadScene("SampleScene");
        languageNum = num;
    }

}
