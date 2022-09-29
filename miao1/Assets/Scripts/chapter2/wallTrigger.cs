using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class wallTrigger : MonoBehaviour
{
    public UnityEvent e;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == GameManager2.instance.player)
        {
            if (e != null)
                e.Invoke();
        }
    }
    public void disableThis()
    {
        this.gameObject.SetActive(false);
    }
}
