using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventControl : MonoBehaviour
{
    public static EventControl Instance;
    public GameObject NPC_StartButton;
    public List<bool> events = new List<bool>();
    public List<string> eventNames = new List<string>();
    public List<Item> moments = new List<Item>();
    //public GameObject transButton;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //showNPC_Button();
        //��ʱ
        /*
        if(GameManager2.instance.items.Contains(moments[0]))
        {
            EventControl.Instance.finishEvent(3);
            EventControl.Instance.finishEvent(4);
        }
        if (GameManager2.instance.items.Contains(moments[1]))
        {
            EventControl.Instance.finishEvent(8);
            EventControl.Instance.finishEvent(9);
        }
        */
    }
    public void eventFinish(int i)
    {
        if(!events[i])
        { 
            events[i] = true;
        }
        
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
        DialogSys2.Instance.dialogFinish();
        if (!events[0] && !events[5])
        {
            DialogSys2.Instance.dialogStart(0);
        }
        if (events[0] && events[1] && !events[2] && !events[5])
        {
            DialogSys2.Instance.dialogStartMoment(false);
        }
        if (events[0] && events[1] && events[2] && !events[3] && !events[5])
        {
            DialogSys2.Instance.dialogStartMoment(true);
            //transButton.SetActive(true);
        }
        if (events[0] && events[1] && events[2] && events[3] && !events[4])
        {
            DialogSys2.Instance.dialogMomentFailed();
            //transButton.SetActive(true);
        }
        if (events[0] && events[1] && events[2] && events[3] && events[4] && !events[5])
        {
            DialogSys2.Instance.dialogStart(12);
            //GameObject.Find("Npc").GetComponent<NpcMusicFocus>().focus(0);
        }
        if (events[5] && !events[7])
        {
            DialogSys2.Instance.dialogStart(48);
        }
        if (events[5] && events[7] && !events[8])
        {
            DialogSys2.Instance.dialogStartMoment(true);
            //transButton.SetActive(true);
        }
        if (events[5] && events[7] && events[8] && !events[9])
        {
            DialogSys2.Instance.dialogMomentFailed();
            //transButton.SetActive(true);
        }
        if (events[5] && events[7] && events[8] && events[9] && !events[10])
        {
            DialogSys2.Instance.dialogStart(14);
        }
        if(events[12] && !events[13])
        {
            DialogSys2.Instance.dialogStart(50);
        }
        if(events[13] && !events[14])
        {
            DialogSys2.Instance.dialogStartMoment(true);
        }
        if(events[14] && !events[15])
        {
            DialogSys2.Instance.dialogMomentFailed();
        }
        if(events[15] && !events[16])
        {
            DialogSys2.Instance.dialogStart(24);
        }
        if(events[17] && !events[18])
        {
            DialogSys2.Instance.dialogStart(51);
        }
        if(events[18] && !events[19])
        {
            DialogSys2.Instance.dialogStartMoment(true);
        }
        if(events[19] && !events[20])
        {
            DialogSys2.Instance.dialogMomentFailed();
        }
        if(events[20] && !events[21])
        {
            DialogSys2.Instance.dialogStart(27);
        }
        if(events[23] && !events[24])
        {
            DialogSys2.Instance.dialogStartMoment(true);
        }
        if(events[22] && !events[23])
        {
            DialogSys2.Instance.dialogStart(52);
        }
        if(events[24] && !events[25])
        {
            DialogSys2.Instance.dialogMomentFailed();
        }
        if(events[25] && !events[26])
        {
            DialogSys2.Instance.dialogStart(31);
        }
        if(events[26] && !events[27])
        {
            DialogSys2.Instance.dialogStart(33);
        }
        if(events[27] && !events[28])
        {
            DialogSys2.Instance.dialogStart(34);
        }
    }
    public void LaoPoPo_ButtonAct()
    {
        if (!events[1])
        {
            DialogSys2.Instance.dialogStart(0);
        }
    }
    public void finishEvent(int i)
    {
        events[i] = true;
    }
    public void test(int n)
    {
        for(int i=0; i<=n; i++)
        {
            events[i] = true;
        }
    }
}
