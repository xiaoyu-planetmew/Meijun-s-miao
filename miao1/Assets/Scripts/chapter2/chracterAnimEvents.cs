using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Spine;
using UnityEngine.Events;

public class chracterAnimEvents : MonoBehaviour
{
    public List<string> animNames = new List<string>();
    public List<bool> animLoops = new List<bool>();
    public List<UnityEvent> afterEvents = new List<UnityEvent>();
    //public List<bool> animacteds = new List<bool>();
    public GameObject NPC;
    public List<string> NPCanimNames = new List<string>();
    public List<bool> NPCanimLoops = new List<bool>();
    public List<UnityEvent> NPCafterEvents = new List<UnityEvent>();
    //public List<bool> NPCanimacteds = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void afterAnimDialog(int num)
    {
        DialogSys2.Instance.dialogStart(num);
    }
    void HandleEvent(TrackEntry trackEntry, Spine.Event e)
    {

    }
    public void playOtherAnim(int i)
    {
        string animationName = animNames[i];
        bool loop = animLoops[i];
        UnityEvent e = afterEvents[i];
        Debug.Log(i);
        if (this.transform.Find("ChracterNew"))
        {
            SkeletonAnimation skeletonAnimation;   //gameobjectµÄcomponent¡£            
            skeletonAnimation = this.transform.Find("ChracterNew").GetComponent<SkeletonAnimation>();
            if (skeletonAnimation == null) return;
            skeletonAnimation.AnimationState.Event += HandleEvent;
            Spine.AnimationState spineAnimationState = skeletonAnimation.state;
            //Spine.Skeleton skeleton;
            this.GetComponent<FinalMovement>().otherAnim = true;
            //skeletonAnimation.skeleton.SetToSetupPose();
            //spineAnimationState.ClearTracks();
            //spineAnimationState.SetAnimation(0, animationName, loop);
            spineAnimationState.SetAnimation(0, animationName, loop).Complete += delegate
            {
                //Debug.Log(skeletonAnimation.AnimationState.GetCurrent(0));

                // ... or choose to ignore its parameters.
                //if (!animacteds[i]) 
                //{
                    //animacteds[i] = true;
                Debug.Log("An animation ended!");
                this.GetComponent<FinalMovement>().otherAnim = false;
                if (e != null)
                {
                    e.Invoke();
                }
                return;
                //}
            };
        }
        return;
    }
    public void jiangSongAnim(int i)
    {
        string animationName = NPCanimNames[i];
        bool loop = NPCanimLoops[i];
        UnityEvent e = NPCafterEvents[i];
        Debug.Log(i);
        if (NPC)
        {
            SkeletonAnimation skeletonAnimation;   //gameobjectµÄcomponent¡£            
            skeletonAnimation = NPC.GetComponent<SkeletonAnimation>();
            if (skeletonAnimation == null) return;
            //skeletonAnimation.AnimationState.Event += HandleEvent;
            Spine.AnimationState spineAnimationState = skeletonAnimation.state;
            //Spine.Skeleton skeleton;
            //this.GetComponent<FinalMovement>().otherAnim = true;
            //skeletonAnimation.skeleton.SetToSetupPose();
            //spineAnimationState.ClearTracks();
            //spineAnimationState.SetAnimation(0, animationName, loop);
            spineAnimationState.SetAnimation(0, animationName, loop).Complete += delegate {
                //if (!NPCanimacteds[i])
                //{
                    //NPCanimacteds[i] = true;
                    // ... or choose to ignore its parameters.
                    Debug.Log("An animation ended!");
                    //this.GetComponent<FinalMovement>().otherAnim = false;
                    spineAnimationState.SetAnimation(0, "widle", true);
                    if (e != null)
                    {
                        e.Invoke();
                    }
                    return;
                //}
            };
        }
        return;
    }
}
