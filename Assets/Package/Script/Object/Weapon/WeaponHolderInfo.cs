using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderInfo : MonoBehaviour
{
    //摘要
    //  負責Player目前操作的武器以及武器資訊
    //  以及Player能否使用手榴彈

    [SerializeField] public WeaponScriptableObject currentWeaponScript; 
    [SerializeField] public Weapon currentWeapon;
    [SerializeField] GameObject grenadePrefab = null;

    private void Update() 
    {
        currentWeapon = GetComponentInChildren<Weapon>();
        currentWeaponScript = GetComponentInChildren<Weapon>().GetWeaponInfo();
    }

    public void ThrowGrenade()
    {
        if (!grenadePrefab)
        {
            return;
        }else
        {
            GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
            Rigidbody rb = grenade.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * GetComponentInParent<PlayerMovemont>().playerForce, ForceMode.VelocityChange);
        }
    }
}
