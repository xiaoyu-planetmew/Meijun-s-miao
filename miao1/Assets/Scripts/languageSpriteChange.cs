using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class languageSpriteChange : MonoBehaviour
{
    public Sprite JanpanessSprite;
    public Sprite EnglishSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.languageNum == 0)
        {
            this.GetComponent<Image>().sprite = JanpanessSprite;
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(JanpanessSprite.bounds.size.x * 100, JanpanessSprite.bounds.size.y * 100);
            //this.GetComponent<Text>().text = JanpanessString;
        }
        if(GameManager.instance.languageNum == 1)
        {
            this.GetComponent<Image>().sprite = EnglishSprite;
            this.GetComponent<RectTransform>().sizeDelta = new Vector2(EnglishSprite.bounds.size.x * 100, EnglishSprite.bounds.size.y * 100);
            //this.GetComponent<Text>().text = EnglishString;
        }
    }
}
