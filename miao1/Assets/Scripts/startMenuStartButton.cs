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
    public void startButtonJ()
    {
        //SceneManager.LoadScene("SampleScene");
        languageNum = 0;
    }
    public void startButtonE()
    {
        //SceneManager.LoadScene("SampleScene");
        languageNum = 1;
    }
}
