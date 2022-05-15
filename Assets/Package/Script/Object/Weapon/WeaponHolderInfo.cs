using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolderInfo : MonoBehaviour
{
    [SerializeField] public WeaponScriptableObject currentWeaponScript; 
    [SerializeField] public Weapon currentWeapon;

    private void Update() 
    {
        currentWeapon = GetComponentInChildren<Weapon>();
        currentWeaponScript = GetComponentInChildren<Weapon>().GetWeaponInfo();
    }
}
