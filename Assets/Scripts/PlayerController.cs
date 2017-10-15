using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //键盘控制移动
    //   public float playerSpeed = 3f;
    //void Update () {
    //       PlayMoving();
    //}
    //   void PlayMoving()
    //   {
    //       if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
    //       {
    //           transform.Translate(Vector2.left* playerSpeed * Time.deltaTime);
    //       }
    //       else if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
    //       {
    //           transform.Translate(Vector2.right* playerSpeed * Time.deltaTime);
    //       }
    //   }

    //鼠标控制移动
    private Vector3 rawPosition;
    private Vector3 hatPosition;
    private float maxWidth;
     void Start()
    {
        Vector3 screenPos = new Vector3(Screen.width, 0, 0);
        Vector3 moveWidth = Camera.main.ScreenToWorldPoint(screenPos);//屏幕坐标转世界坐标
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;//获取帽子宽度
        hatPosition = transform.position;
        maxWidth = moveWidth.x - hatWidth;
    }
    private void FixedUpdate()
    {
        rawPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//鼠标点击的位置转换世界坐标
        hatPosition = new Vector3(rawPosition.x,hatPosition.y,0);
        hatPosition.x = Mathf.Clamp(hatPosition.x,-maxWidth,maxWidth);//距离
        GetComponent<Rigidbody2D>().MovePosition(hatPosition);//移动
    }

}
