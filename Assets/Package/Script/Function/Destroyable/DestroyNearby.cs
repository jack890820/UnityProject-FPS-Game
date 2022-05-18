using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNearby : MonoBehaviour
{
    //摘要
    //  爆炸功能
    //  需要使用時呼叫Expoled()方法
    //  或使用繼承

    [SerializeField] public Transform explosionCenter; //爆炸本體
    [SerializeField] GameObject explosionEffect; //爆炸特效
    [SerializeField] public float radius; //爆炸範圍
    [SerializeField] public float force; //爆炸力道
    [SerializeField] public bool isExpoled; //是否爆炸

    void Start() 
    {
        
    }

    void Update() 
    {
        
    }

    public void Expoled()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation); //在爆炸本體生成爆炸特效

        Collider[] collidersToDestroy = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Destroyable")); //偵測以爆炸本體為中心的爆炸範圍內的Collider

        foreach(Collider nearbyObject in collidersToDestroy) //循環被偵測到在爆炸範圍內的collider
        {
            Destructible destructible = nearbyObject.GetComponent<Destructible>(); //尋找在爆炸範圍內的collider的組件
            if(destructible != null)
            {
                destructible.Destroy(); //呼叫組件裡的方法Destroy
            }
        }

        Collider[] collidersToMove = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Destroyable"));

        foreach(Collider nearbyObject in collidersToMove)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>(); //設定區域變數rb為爆炸範圍內collider的Rigidbody
            if(rb != null) //如果有rb組件
            {
                rb.AddExplosionForce(force, transform.position, radius); //在爆炸範圍內加入爆炸力道
            }
        }

        Destroy(gameObject);       
    }

    void OnDrawGizmosSelected() //繪出物體radius
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(explosionCenter.position, radius);
    }
}
