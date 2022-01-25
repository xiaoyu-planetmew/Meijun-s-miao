using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportButtonActive : MonoBehaviour
{
    public GameObject buttonLocation;
    public GameObject button;
    public Item _item;
    public int e;
    GameObject player;
    public float jumpDistance;
    bool holdItem = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_item != null && !GameManager.instance.events[e])
        {
            if(!GameManager.instance.items.Contains(_item))
            {
                holdItem = false;
            }else{
                holdItem = true;
            }
        }else{
            holdItem = true;
        }
        player = GameManager.instance.player;
        if((Mathf.Abs(buttonLocation.transform.position.x - player.transform.position.x) < jumpDistance) 
        && (Mathf.Abs(buttonLocation.transform.position.y - player.transform.position.y) < 10) && holdItem)
        {
            button.SetActive(true);
        }
        if((Mathf.Abs(buttonLocation.transform.position.x - player.transform.position.x) > jumpDistance) 
        || (Mathf.Abs(buttonLocation.transform.position.y - player.transform.position.y) > 10)&& holdItem)
        {
            button.SetActive(false);
        }
    }
    public void turn()
    {
        _item = null;
        //GameManager.instance.player.GetComponent<FinalMovement>().continueMoving();
    }
}
