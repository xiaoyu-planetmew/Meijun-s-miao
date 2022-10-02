using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSet : MonoBehaviour
{
    public static MouseSet Instance;
    public bool inGUI = false;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        nowTexture = mouseTexture;
        nowx = mousex;
        nowy = mousey;
    }
    public Texture nowTexture;
    public int nowx;
    public int nowy;
    public Texture mouseTexture;
    public int mousex;
    public int mousey;
    public Texture axe1;
    public int axe1x;
    public int axe1y;
    public Texture axe2;
    public int axe2x;
    public int axe2y;



    void Update()
    {
        /*
        if(inGUI)
        {
            mouseTexture = mouseTexture2;
        }
        else
        {
            mouseTexture = mouseTexture1;
        }
        */
    }
    void OnGUI()
    {
        Cursor.visible = false;//“˛≤ÿ Û±Í÷∏’Î
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, nowx, nowy), nowTexture);
    }
    public void mouseChange(string s)
    {
        if(s == "mouseTexture")
        {
            nowTexture = mouseTexture;
            nowx = mousex;
            nowy = mousey;
        }
        if (s == "axe1")
        {
            nowTexture = axe1;
            nowx = axe1x;
            nowy = axe1y;
        }
        if (s == "axe2")
        {
            nowTexture = axe2;
            nowx = axe2x;
            nowy = axe2y;
        }
    }
    // Update is called once per frame
    
}
