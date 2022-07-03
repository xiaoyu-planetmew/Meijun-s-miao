using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalJump : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public GameObject mask;
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
