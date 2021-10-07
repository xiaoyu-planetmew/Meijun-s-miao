using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcChat : MonoBehaviour
{
    public GameObject button;
    public GameObject chatUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            button.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            button.SetActive(false);
        }
    }
    private void Update()
    {
        if(button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            chatUI.SetActive(true);
        }
        /*if(chatUI.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            chatUI.SetActive(false);
        }*/
    }
}
