using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //摘要
    //  負責Player按鍵操作

    [SerializeField] public GameObject miniMap;

    void Start()
    {
        miniMap.SetActive(false);
    }

    void Update()
    {
        OpenMiniMap();

        if(!gameObject.GetComponentInChildren<Weapon>())
        {
            return;
        }
        Fire();
        Reload();
        ThrowingGrenade();
    }

    private void OpenMiniMap()
    {
        if (Input.GetKeyDown(KeyCode.M) && miniMap.activeSelf == false)
        {
            miniMap.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.M) && miniMap.activeSelf == true)
        {
            miniMap.SetActive(false);
        }
    }

    private void Fire()
    {
        if (Input.GetMouseButton(0))
        {
            gameObject.GetComponentInChildren<Weapon>().Fire();
        }
    }

    private void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameObject.GetComponentInChildren<Weapon>().Reload();
        }
    }

    private void ThrowingGrenade()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameObject.GetComponentInChildren<WeaponHolderInfo>().ThrowGrenade();
        }
    }
}
