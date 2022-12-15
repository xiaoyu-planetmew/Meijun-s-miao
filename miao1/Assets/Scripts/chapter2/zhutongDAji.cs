using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zhutongDAji : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.gameObject.GetComponent<Image>().enabled = true;
            transform.GetComponent<RectTransform>().localPosition = new Vector2(Input.mousePosition.x - Screen.width / 2f ,Input.mousePosition.y - Screen.height / 2f);
            transform.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, Random.Range(-180, 180));
            StopAllCoroutines();
            StartCoroutine(close());
        }
    }
    IEnumerator close()
    {
        yield return new WaitForSeconds(0.5f);
        {
            this.gameObject.GetComponent<Image>().enabled = false;
        }
    }
}
