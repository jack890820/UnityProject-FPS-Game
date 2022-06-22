using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    //摘要
    //  武器彈藥資訊

    [SerializeField] private WeaponHolderInfo weaponHolderInfo;
    [SerializeField] private Weapon currentWeaponInfo;
    [SerializeField] private TMP_Text ammoCount;
    [SerializeField] private TMP_Text maxAmmoCount;
    [SerializeField] private TMP_Text grenadeCount;

    private void Update()
    {
        currentWeaponInfo = weaponHolderInfo.currentWeapon;
        
        AmmoUIUpdate();
    }

    private void AmmoUIUpdate()
    {
        string grenadeCountString = weaponHolderInfo.grenadeCount.ToString();
        grenadeCount.text = grenadeCountString;

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
