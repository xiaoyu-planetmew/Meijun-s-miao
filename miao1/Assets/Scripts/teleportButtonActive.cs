using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportButtonActive : MonoBehaviour
{
    public GameObject buttonLocation;
    public GameObject button;
    public GameObject player;
    public float jumpDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Mathf.Abs(buttonLocation.transform.position.x - player.transform.position.x) < jumpDistance) && (Mathf.Abs(buttonLocation.transform.position.y - player.transform.position.y) < 10))
        {
            button.SetActive(true);
        }
        if((Mathf.Abs(buttonLocation.transform.position.x - player.transform.position.x) > jumpDistance) || (Mathf.Abs(buttonLocation.transform.position.y - player.transform.position.y) > 10))
        {
            button.SetActive(false);
        }
    }
}