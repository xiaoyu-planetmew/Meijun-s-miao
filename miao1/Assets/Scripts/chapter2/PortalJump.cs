using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalJump : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public GameObject mask;
    public bool underWater = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void teleport()
    {
        player.transform.position = target.transform.position;
        if(underWater)
        {
            player.GetComponent<PlayerUnderWaterControl>().underWater = true;
        }else{
            player.GetComponent<PlayerUnderWaterControl>().underWater = false;
        }
        StartCoroutine(ShowMask());
    }
    IEnumerator ShowMask()
    {
        mask.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<FinalMovement>().canMove = false;
        yield return new WaitForSeconds(1f);
        Debug.Log("1");
        mask.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<FinalMovement>().canMove = true;
    }
}
