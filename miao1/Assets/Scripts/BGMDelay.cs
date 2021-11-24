using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDelay : MonoBehaviour
{
    public float delayTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(delayTime);
        this.gameObject.GetComponent<AudioSource>().Play();
    }
}
