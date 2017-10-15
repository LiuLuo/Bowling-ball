using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowwlingBallPool : MonoBehaviour {

 
    public  static BowwlingBallPool _instance;//对象池单例
     void Awake()
    {
        _instance = this;
    }
    public GameObject bowlingBallPrefeb;//对象预设体
    public int pooledAmount = 5;//对象池初始大小
    public bool lockPoolSize = false;//是否锁定对象池大小
    private List<GameObject> pooledObjects;//对象池链表；
    private int currenIndex = 0;//初始链表位置索引
    void Start () {
        pooledObjects = new List<GameObject>();//初始化链表
        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject go = Instantiate(bowlingBallPrefeb);//创建对象
            go.SetActive(false);//隐藏
            pooledObjects.Add(go);//将对象添加到链表
        }
	}
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; ++i)
        {//遍历上一次使用的对象的下一个（贪心算法）
            int temI = (currenIndex + i) % pooledObjects.Count;
            if (!pooledObjects[temI].activeInHierarchy)//判断对象是否激活
            {
                currenIndex = (temI + 1) % pooledObjects.Count;               
                return pooledObjects[temI];//找到未被激活对象并返回
            }
        }
        //遍历完对象池发现没有可用对象，折行下面
        if (!lockPoolSize)//如果没有锁定对象池大小，创建对象添加到对象池并返回
        {
            GameObject go = Instantiate(bowlingBallPrefeb);
            pooledObjects.Add(go);
            return go;
        }
        return null;    //如果锁定了对象池大小返回空
    }

}
