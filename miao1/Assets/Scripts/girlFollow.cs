using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = GameManager.instance.player.transform.position;
    }
}
