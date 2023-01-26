using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class girlAnimTest : MonoBehaviour
{ 
    public Animator anim;

    void Start()
    {
        //Addressables.LoadAssetsAsync<RuntimeAnimatorController>(assetLabel, OnLoadDone);
        Addressables.LoadAssetAsync<RuntimeAnimatorController>("sequenceFrame/女孩的诗/girlAnim.controllerrlAnim.controller").Completed += OnLoadDone;
    }

    /// <summary>
    /// 资源加载完成回调，此处可以加一个进度显示和交互限制，等待加载完毕之后再操作，防止异常
    /// </summary>
    /// <param name="animtorClip"></param>
    /*void OnLoadDone(RuntimeAnimatorController animtorClip)
    {
        Debug.Log(animtorClip.name);
        this.GetComponent<Animator>().runtimeAnimatorController = animtorClip;
        this.GetComponent<Animator>().enabled = true;
    }*/
   private void OnLoadDone(UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<RuntimeAnimatorController> obj)
    {
        // In a production environment, you should add exception handling to catch scenarios such as a null result.
        anim.runtimeAnimatorController = obj.Result;
        this.GetComponent<girlAnim>().enabled = true;
    }
}