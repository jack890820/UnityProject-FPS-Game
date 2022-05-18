using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNearby : MonoBehaviour
{
    [SerializeField] public Transform explosionCenter;
    [SerializeField] float radius;
    
    void OnDrawGizmosSelected() //繪出物體radius
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(explosionCenter.position, radius);
    }
}
