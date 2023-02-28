using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiggler : MonoBehaviour
{
    public GameObject target;
    public GameObject cam;
    public bool move;
    Vector3 mouseStartMovePos;
    //鼠标按下时 target的位置
    Vector3 targetStartMovePos;
    private void FixedUpdate() {
        //FollowMove();
        target.transform.position = cam.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, cam.transform.position.z * -1f));
    }
    private void FollowMove()
    {
        //将 target世界坐标转换成屏幕坐标
        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(target.transform.position);
        //修正鼠标点的坐标
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetScreenPos.z);
        //将 修正后的鼠标点 转换成世界坐标
        Vector3 mouseSToW = Camera.main.ScreenToWorldPoint(mousePos);
 
        //鼠标按下时记录 鼠标点的位置 和 target的位置
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartMovePos = mouseSToW ;
            targetStartMovePos = target.transform.position;
        }
        //跟随移动，加上偏移
        if (Input.GetMouseButton(0))
        {
            target.transform.position = targetStartMovePos + mouseSToW - mouseStartMovePos;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 12)
        {
            this.transform.parent.gameObject.GetComponent<windChime>().chimeAudio(this.gameObject);
            Debug.Log("chime1");
        }
    }
}