using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObject/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] private string weaponName;
    [SerializeField] private float fireRate;
    [SerializeField] private bool semiAuto;

    public string WeaponName => weaponName;
    public float FireRate => fireRate;
    public bool SemiAuto => semiAuto;

}
