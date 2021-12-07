using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem: MonoBehaviour
{
    public Item itemData;
    //public GameObject pickupEffect;
/*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.instance.items.Count < GameManager.instance.slots.Length)//Items number greater than the Inventory Grid total/max numbers
            {
                //Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);

                GameManager.instance.AddItem(itemData);
            }
            else
            {
                Debug.Log("You CANNOT PICK UP ANY ITEMS NOW. YOUR BAG IS FULL!!!");
            }

        }
    }
*/
    public void pickUp()
    {
        if (GameManager.instance.items.Count < GameManager.instance.slots.Count)//Items number greater than the Inventory Grid total/max numbers
            {
                //Instantiate(pickupEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);

                GameManager.instance.AddItem(itemData);
            }
            else
            {
                Debug.Log("You CANNOT PICK UP ANY ITEMS NOW. YOUR BAG IS FULL!!!");
            }
    }

}