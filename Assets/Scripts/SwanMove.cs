using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwanMove : MonoBehaviour {
    public float speed=5f;//速度
    public float x = 8f;//返回位置
	void Update () {
        //飞出游戏视窗后返回设定位置循环飞行
        if (transform.position.x>=-8)
        {        
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }
	}
}
