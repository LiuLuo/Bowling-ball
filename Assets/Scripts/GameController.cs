using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float timeInterval =2f;
    private float time ;
    // Update is called once per frame
   void Start()
    {
        time = timeInterval;
    }
    void Update() {
        ProduceBowlingBall();
    }
    void ProduceBowlingBall()
    {
        time  -= Time.deltaTime;   
        if (time <=0)
        {
            float x = Random.Range(-7.1f, 7.1f);
            //传统创建游戏对象的方法
            //Instantiate(shotObj, shotSpawn.transform.position, shotSpawn.transform.rotation);
            //获取对象池中的对象
            GameObject bow = BowwlingBallPool._instance.GetPooledObject();
            bow.transform.position = new Vector3(x,6.64f,0);   
            bow.SetActive(true);     
            time = timeInterval;        
        } 
    }
}
