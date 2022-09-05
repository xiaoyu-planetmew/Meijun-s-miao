using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControl : MonoBehaviour
{
    public static EventControl Instance;
    public GameObject NPC_StartButton;
    public List<bool> events = new List<bool>();
    public List<string> eventNames = new List<string>();
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        showNPC_Button();
    }
    public void eventFinish(int i)
    {
        events[i] = true;
    }
    void showNPC_Button()
    {
        if(events[0] == true)
        {
            NPC_StartButton.transform.parent.GetComponent<NearShow>().enabled = false;
            NPC_StartButton.SetActive(false);
        }
        if(events[0] == false)
        {
            NPC_StartButton.transform.parent.GetComponent<NearShow>().enabled = true;
            NPC_StartButton.SetActive(true);
        }
    }
    public void NPC_ButtonAct()
    {
        if(!events[0])
        {
            DialogSys2.Instance.dialogStart(0);
        }
    }
    public void LaoPoPo_ButtonAct()
    {
        if (!events[1])
        {
            DialogSys2.Instance.dialogStart(0);
        }
    }
}
