using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraFocus : MonoBehaviour
{
    public Transform focusLocation;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void focus()
    {
        this.GetComponent<CinemachineBrain>().enabled = false;
        StartCoroutine(MoveToPosition());
    }
    public void cancelFocus()
    {
       this.GetComponent<CinemachineBrain>().enabled = true;
    }
    IEnumerator MoveToPosition()
    {     
        while (gameObject.transform.position != focusLocation.position)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, focusLocation.position, speed * Time.deltaTime);
            yield return 0;
        }
    }
}
