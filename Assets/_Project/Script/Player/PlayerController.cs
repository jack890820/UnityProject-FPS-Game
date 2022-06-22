using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestSubjectCode
{
    public class PlayerController : MonoBehaviour
    {
        //摘要
        //  負責Player按鍵操作

        [SerializeField] public GameObject miniMap;
        [SerializeField] KeyCode openMiniMapKey = KeyCode.M;
        [SerializeField] KeyCode fireKey = KeyCode.Mouse0;
        [SerializeField] KeyCode reloadKey = KeyCode.R;
        [SerializeField] KeyCode throwingGrenadeKey = KeyCode.G;

        void Start()
        {
            miniMap.SetActive(false);
        }

        void Update()
        {
            if(Time.timeScale == 0) return;
            OpenMiniMap();
            ThrowingGrenade();

            if(!gameObject.GetComponentInChildren<Weapon>()) return;
            
            Fire();
            Reload();                
        }

        private void OpenMiniMap()
        {
            if (Input.GetKeyDown(openMiniMapKey) && miniMap.activeSelf == false)
            {
                miniMap.SetActive(true);
            }
            else if (Input.GetKeyDown(openMiniMapKey) && miniMap.activeSelf == true)
            {
                miniMap.SetActive(false);
            }
        }

        private void Fire()
        {
            if (Input.GetKey(fireKey))
            {
                gameObject.GetComponentInChildren<Weapon>().Fire();
            }
        }

        private void Reload()
        {
            if (Input.GetKeyDown(reloadKey))
            {
                gameObject.GetComponentInChildren<Weapon>().Reload();
            }
        }

        private void ThrowingGrenade()
        {
            if (Input.GetKeyDown(throwingGrenadeKey))
            {
                gameObject.GetComponentInChildren<WeaponHolderInfo>().ThrowGrenade();
            }
        }
    }
}