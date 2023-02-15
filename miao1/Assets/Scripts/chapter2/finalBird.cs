using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class finalBird : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void lu1()
    {
        transform.position = new Vector3(-33.68f, -0.65f, 0);
        this.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "idle", true);
    }
    public void lu2()
    {
        transform.position = new Vector3(-35.01f, -0.65f, 0);
        this.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "idle", true);
    }
}
