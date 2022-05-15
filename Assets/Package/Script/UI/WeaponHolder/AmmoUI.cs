using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private WeaponHolderInfo weaponHolderInfo;
    [SerializeField] private Weapon currentWeaponInfo;
    [SerializeField] private TMP_Text ammoCount;
    [SerializeField] private TMP_Text maxAmmoCount;

    private void Update()
    {
        currentWeaponInfo = weaponHolderInfo.currentWeapon;
        
        AmmoUIUpdate();
    }

    private void AmmoUIUpdate()
    {
        if(currentWeaponInfo == null)
        {
            return;
        }else
        {
            string ammoCountString = currentWeaponInfo.ammoCount.ToString();
            string maxAmmoCountString = currentWeaponInfo.maxAmmoCount.ToString();


            ammoCount.text = ammoCountString;
            maxAmmoCount.text = maxAmmoCountString;
        }        
    }
}
