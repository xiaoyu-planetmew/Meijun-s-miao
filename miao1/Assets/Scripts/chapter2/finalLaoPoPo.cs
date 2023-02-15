using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class finalLaoPoPo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeAnim()
    {
        this.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "happy", true);
    }
}
