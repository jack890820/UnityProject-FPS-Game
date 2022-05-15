using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour, IDestroyable
{

    [SerializeField]protected string type = " ";
    [SerializeField]protected int health = 0;

    //Destroyable
    [SerializeField]public AudioSource audioSource;
    [SerializeField]public AudioClip destroySound;
    [SerializeField]public UnityEngine.Object[] destroyableNearby;

    [SerializeField]public float radius = 10f;
    [SerializeField] public Transform ibObject;


    public void Start()
    {
        
    }

    void Update()
    {
        ColliderDestroy();
        DestroyObject();
    }

    public void ColliderDestroy()
    {
        UnityEngine.Object[] destroyableNearby = Physics.OverlapSphere(ibObject.position, radius, LayerMask.GetMask("Destroyable"));
        //尚未解決摧毀主物件周遭的物件
    }

    public void DestroyObject() //interface 摧毀物體
    {        
        foreach(UnityEngine.Object destroyable in destroyableNearby)
        {            
            Destroy(destroyable);
            audioSource.PlayOneShot(destroySound, 1f);
        }
    }

    public void OnDrawGizmosSelected() //繪出物體radius
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(ibObject.position, radius);
    }
}
