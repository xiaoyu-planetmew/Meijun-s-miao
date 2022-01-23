using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraShake : MonoBehaviour
{
    public float shakeTime = 0.0f;
    private float fps = 20.0f;
    private float frameTime = 0.0f;
    private float shakeDelta = 0.005f;
    public Camera cam;
    public  bool isShakingCamera = false;
    // Start is called before the first frame update
    void Start()
    {
        shakeTime = 2f;
        fps = 20f;
        frameTime = 0.03f;
        shakeDelta = 0.005f;
        //isShakingCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isShakingCamera)
        {
            if(shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
                if(shakeTime <= 0)
                {
                    if(cam.name == "Main Camera")
                    {
                        cam.gameObject.GetComponent<CinemachineBrain>().enabled = true;
                    }
                    isShakingCamera = false;
                    shakeTime = 2f;
                    fps = 20f;
                    frameTime = 0.03f;
                    shakeDelta = 0.005f;
                }
                else
                {
                    frameTime += Time.deltaTime;
                    if(frameTime > 1 / fps)
                    {
                        frameTime = 0;
                        if(cam.name == "Main Camera")
                        {
                            cam.gameObject.GetComponent<CinemachineBrain>().enabled = false;
                        }
                        cam.rect = new Rect(shakeDelta * (-1f + 2f * Random.value), shakeDelta * (-1f + 2f * Random.value), 1f, 1f);                     
                    }
                }
            }
        }
    }
}
