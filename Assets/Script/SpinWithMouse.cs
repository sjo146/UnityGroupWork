using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWithMouse : MonoBehaviour
{
    //调用条件是一定要有碰撞盒
    public float length = 5;
    private bool isClick = false;
    private Vector3 nowPos;
    private Vector3 oldPos;
    private void OnMouseUp()
    {
        isClick = false;
    }
    private void OnMouseDown()
    {
        isClick = true;
    }
    private void Update()
    {
        nowPos = Input.mousePosition;
        if (isClick)
        {
            Vector3 offset = nowPos - oldPos;
            if (Mathf.Abs(offset.x) > Mathf.Abs(offset.y) && Mathf.Abs(offset.x) > length)
                transform.Rotate(Vector3.up, -offset.x);//沿着x轴旋转
        
        }
        oldPos = Input.mousePosition;
    }
}
