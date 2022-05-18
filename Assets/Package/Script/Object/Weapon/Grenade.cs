using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : DestroyNearby
{
    //摘要
    //  繼承DestroyNearby組件功能的組件
    //  手榴彈

    [SerializeField] float delay = 5f;    
    float countDown;

    private void Start() 
    {
        countDown = delay;        
    }

    private void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0f && !isExpoled)
        {
            Expoled();
        }
    }

    void OnDrawGizmosSelected() //繪出物體radius
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(explosionCenter.position, radius);
    }
}
