using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using Spine.Unity;
public class bambooAni : MonoBehaviour
{
    public List<GameObject> bamaoAni = new List<GameObject>();
    [SerializeField] float growTime;
    // Start is called before the first frame update
    void Start()
    {
        growTime = bamaoAni[0].GetComponent<SkeletonAnimation>().skeletonDataAsset.GetAnimationStateData().SkeletonData.FindAnimation("grow").Duration;
        growTime = growTime / 0.2f;
        getStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getStart()
    {
        foreach(var obj in bamaoAni)
        {
            obj.gameObject.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "grow", false);
            obj.gameObject.GetComponent<SkeletonAnimation>().timeScale = 0.2f;
            
            StartCoroutine(shakeStart(obj));
        }
    }
    IEnumerator shakeStart(GameObject obj)
    {
        yield return new WaitForSeconds(growTime);
        obj.gameObject.GetComponent<SkeletonAnimation>().state.SetAnimation(0, "shake", true);
        obj.gameObject.GetComponent<SkeletonAnimation>().timeScale = 0.3f;
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(10f);
        getStart();
    }
}
