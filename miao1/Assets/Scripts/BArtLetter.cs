using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BArtLetter : MonoBehaviour
{
    public Texture[] letters;
    public GameObject letter;
    public int num = 6;
    [Range(0,1)] public float lettersSize = 1;
    public float wordSpace;
    [SerializeField] private int showNumber;
    private int storedNumber;
    
    private RawImage[] images;
    private float localScaleX = 0.47f;
    private Animator[] anims;
    private bool startAddEffect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void InitialNumbers()
    {
        
        images = new RawImage[num];
        for(int i = 0;i<num;i++)
        {
            GameObject obj = Instantiate((letter));
            images[i] = obj.GetComponent<RawImage>();
            obj.transform.SetParent(transform);
            obj.GetComponent<RectTransform>().localPosition = Vector3.left * (wordSpace) * i;
            obj.GetComponent<RectTransform>().localScale = new Vector3(localScaleX * lettersSize, lettersSize, 1);
        }
    }

    /// <summary>
    /// 更新显示的数字
    /// </summary>
    public void UpdateShowLetters()
    {
        var l = showNumber.ToString().ToCharArray();
        num = l.Length;
        for (int i = 0; i < num; i++)
        {
            images[i].texture = letters[Mathf.FloorToInt((showNumber / Mathf.Pow(10, i))) % 10];
        }
    }
}
