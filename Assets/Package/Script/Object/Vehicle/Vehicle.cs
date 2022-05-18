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
    [SerializeField]public float radius = 10f;
    [SerializeField] public Transform ibObject;
    [SerializeField] Collider mainObject;
    [SerializeField] List<GameObject> destroyableNearby;

    public void Start()
    {
        List<GameObject> destroyableNearby = new List<GameObject>();
    }

    void Update()
    {
        OnTriggerEnter(mainObject);
        OnTriggerExit(mainObject);
        //DestroyObject();
    } 

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Destroyable"))
        {
            destroyableNearby.Add(other.attachedRigidbody.gameObject);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Destroyable"))
        {
            destroyableNearby.Remove(other.attachedRigidbody.gameObject);
        }
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
