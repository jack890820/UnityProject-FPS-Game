using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TestSubjectCode
{
    public class Weapon : Launcher
    {
        //摘要
        //  武器
        //  射擊、裝填方法
        
        [SerializeField]WeaponScriptableObject weaponType; //武器資訊
        [SerializeField] public int maxAmmoCount; //最大彈藥數    
        public int ammoCount; //彈藥數
        [SerializeField] float fireRate, maxreloadTime, doubleClickTime; //射速, 最大裝填時間, 雙擊時間
        public float reloadTime, lastClickTime, fillAmountReload, lastFireTime; //裝填時間, 最後點擊時間, 裝填進度條, 最後開火時間
        [SerializeField] public Image progressBarReload; //裝填進度條
        [SerializeField] public bool semiAuto , reloading; //半自動, 裝填中
        
        private void Start()
        {
            ammoCount = maxAmmoCount; //設定彈藥數為最大彈藥數
            reloadTime = maxreloadTime; //設定裝填時間為最大裝填時間

            fireRate = weaponType.FireRate;
            semiAuto = weaponType.SemiAuto;
        }

        void Update()
        {
            Loading();
        }

        private void Loading()
        {
            if (reloading == true) //即使彈藥全滿還是能裝填
            {
                fillAmountReload += (Time.deltaTime / reloadTime); //裝填進度條 等於 遊戲時間除於裝填時間
                progressBarReload.fillAmount = fillAmountReload; //讓裝填進度條進度等同裝填時間
            }
        }

        public void Reload()
        {
            if (reloading == false) //當按下且不再裝填中時才執行
            {
                StartCoroutine(IEReload()); //開始裝填

                float timSinceLastClick = Time.time - lastClickTime; //區域變數 自從上一次點擊 時間為 遊戲時間 - 最後點擊時間

                if(timSinceLastClick <= doubleClickTime) //雙擊 當 自從上一次點擊 小於等於 雙擊時間 時執行
                {
                    reloadTime = maxreloadTime / 2; //裝填時間減半
                    StartCoroutine(IEReload()); //開始裝填
                }else //單擊
                {
                    StartCoroutine(IEReload()); //開始裝填
                }

                lastClickTime = Time.time; // 最後點擊時間 = 遊戲時間
            }
        }

        public override void Fire()
        {
            if(!(ammoCount == 0) && reloading == false) //當按下且彈藥數不為零也不在裝填中時 才執行
            {
                if(Time.time > (60/fireRate) + lastFireTime) //設定武器開火延遲 60/fireRate(每分鐘設速)
                {
                    base.Fire();
                    lastFireTime = Time.time; //最後開火時間 = 遊戲時間
                    ammoCount--; //消耗彈藥
                }
            }
        }

        IEnumerator IEReload()
        {
            yield return new WaitForSeconds(doubleClickTime + .05f); //等待雙擊機會
            reloading = true; //裝填中
            yield return new WaitForSecondsRealtime(reloadTime); //裝填時間
            ammoCount = maxAmmoCount; //裝填完後彈藥數等於最大彈藥數
            fillAmountReload = 0; //清除裝填進度條
            progressBarReload.fillAmount = 0; //清除裝填進度條
            reloadTime = maxreloadTime; //重設裝填時間
            reloading = false; //狀態設為不再裝填中
        }

        public WeaponScriptableObject GetWeaponInfo()
        {
            return weaponType;
        }
    }
}