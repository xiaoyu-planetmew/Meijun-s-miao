using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJumpDown : MonoBehaviour
{
    [SerializeField] private bool onGround;
    public LayerMask ground;
    public float fallTime;
    public float g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(this.transform.position, 0.1f, ground);
        if(onGround)
        {
            this.transform.parent.GetComponent<CircleCollider2D>().isTrigger = false;
        }
        if(Input.GetKeyDown("s") && !onGround)
        {
            this.transform.parent.GetComponent<CircleCollider2D>().isTrigger = true;
            this.transform.parent.GetComponent<Rigidbody2D>().gravityScale = g;
            StartCoroutine(falldown());
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "ground")
        {
           
            onGround = true;
            
        }              
    }
    IEnumerator falldown()
    {
        yield return new WaitForSeconds(fallTime);
        this.transform.parent.GetComponent<CircleCollider2D>().isTrigger = false;
        this.transform.parent.GetComponent<Rigidbody2D>().gravityScale = 15;
    }
}
