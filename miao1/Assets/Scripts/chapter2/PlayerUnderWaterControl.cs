using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnderWaterControl : MonoBehaviour
{
    public bool underWater = false;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<FinalMovement>().canMove)
        {
            //this.gameObject.GetComponent<FinalMovement>().canMove = true;
            this.gameObject.GetComponent<UnderWaterMove>().canMove = true;
        }
        if(!this.gameObject.GetComponent<FinalMovement>().canMove)
        {
            this.gameObject.GetComponent<UnderWaterMove>().canMove = false;
        }
        if(underWater)
        {
            Physics2D.gravity = new Vector3(0, 0, 0);
            this.gameObject.GetComponent<FinalMovement>().enabled = false;
            this.gameObject.GetComponent<UnderWaterMove>().enabled = true;
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            this.gameObject.GetComponent<PlatformEffector2D>().useOneWay = false;
            this.transform.Find("groundcheck").GetComponent<playerJumpDown>().enabled = false;
        }
        if(!underWater)
        {
            Physics2D.gravity = new Vector3(0, -15f, 0);
            this.gameObject.GetComponent<FinalMovement>().enabled = true;
            this.gameObject.GetComponent<UnderWaterMove>().enabled = false;
            this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            if(!this.gameObject.GetComponent<PlatformEffector2D>().useOneWay)
            this.gameObject.GetComponent<PlatformEffector2D>().useOneWay = true;
            this.transform.Find("groundcheck").GetComponent<playerJumpDown>().enabled = true;
        }
    }
}
