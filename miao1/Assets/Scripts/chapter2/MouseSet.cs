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
        
    }
    
    public Texture mouseTexture;
    public Texture mouseTexture1;
    public Texture mouseTexture2;
    public int x;
    public int y;

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
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, x, y), mouseTexture);
    }
    public void mouseChange(bool b)
    {
        inGUI = b;
    }
    // Update is called once per frame
    
}
