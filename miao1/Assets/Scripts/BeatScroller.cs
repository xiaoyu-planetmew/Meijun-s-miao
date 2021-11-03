using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class BeatScroller : MonoBehaviour
{ 
    public float beatTempo;
    public bool hasStarted;
    public int number;
    public float _angle;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        
        beatTempo = beatTempo / 60f;
        _angle = (this.transform.eulerAngles.z * Mathf.Deg2Rad);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            /*if (Input.anyKeyDown)
            {
                hasStarted = true;
            }*/
        }
        else if (number == 2)
        {
            transform.Translate(new Vector3(beatTempo * Mathf.Cos(_angle) * -1f * Time.deltaTime, beatTempo * Mathf.Sin(_angle) * -1f* Time.deltaTime, 0), Space.World);//√ø√Î“∆∂Ø2æ‡¿Î
        }
        else if (number == 1)
        {
            transform.Translate(new Vector3(beatTempo * Mathf.Cos(_angle) * Time.deltaTime, beatTempo * Mathf.Sin(_angle) * Time.deltaTime, 0) , Space.World);
            Debug.Log(Mathf.Cos(_angle));
            Debug.Log(Mathf.Sin(_angle));
            //transform.position -= new Vector3(beatTempo * Time.deltaTime * -1f, 0f, 0f);
        }
    }    


}
