using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMenuMouse : MonoBehaviour
{
    public Texture nowTexture;
    public int nowx;
    public int nowy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        Cursor.visible = false;//�������ָ��
        GUI.DrawTexture(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, nowx, nowy), nowTexture);
    }
}
