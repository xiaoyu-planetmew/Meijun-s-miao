using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {


	public int sceneNum;
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(StartGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void StartGame()
    {
        SceneManager.LoadSceneAsync(sceneNum);
		
        Time.timeScale = 1.0f;
        GameManager.instance.isPaused = false;
    }
}
