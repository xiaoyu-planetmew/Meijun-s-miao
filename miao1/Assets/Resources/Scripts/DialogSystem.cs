using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    [Header("UIModule")]
    public GameObject textLabel;
    public Image faceImage;
    [Header("TextFile")]
    public TextAsset textFile;
    public int index;
    public List<string> textList = new List<string>();
    public bool jump;
    public GameObject transButton;
    private int fileCount;

    // Start is called before the first frame update
    void Awake()
    {
        GetTextFromFile(textFile);
    }
    private void OnEnable()
    {
        textLabel.GetComponent<TMP_Text>().text = textList[index];
        index++;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log(textList.Count);
        fileCount = textList.Count;
        if (jump)
        {
            fileCount = textList.Count + 1;
            //textList[fileCount] = "Oh!I remember something!";
            Debug.Log(fileCount);
        }
        if (Input.GetKeyDown(KeyCode.E) && index == fileCount)
        {
            
                gameObject.SetActive(false);
            transButton.SetActive(false);
            index = 0;
                return;
            
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if((index == fileCount - 1) && jump)
            {
                textLabel.GetComponent<TMP_Text>().text = "Oh!I remember something!";
                transButton.SetActive(true);
                index++;
            }else
            {
                textLabel.GetComponent<TMP_Text>().text = textList[index];
                index++;
            }
            
        }
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;
        var lineDate = file.text.Split('\n');
        foreach(var line in lineDate)
        {
            textList.Add(line);
        }
    }
}
