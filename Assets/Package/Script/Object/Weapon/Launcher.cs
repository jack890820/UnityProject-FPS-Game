using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour
{
    //摘要
    //  發射器組件
    //  直接使用繼承修改
    //  物件池與物件產生的位置(muzzle)

    [SerializeField] Transform muzzle;
    [SerializeField] Bullet bulletPrefab; //物件Prefab
    private IObjectPool<Bullet> bulletPool; //物件池

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(
            CreateBullet, //利用CreateBullet方法設定物件池生成物件
            OnGet, //設定物件為可見
            OnRelease, //設定物件為不可見
            OnDestroyObj, //摧毀物件(當物件數量大於物件池最大容量時，摧毀物件直到數量等於最大容量)
            maxSize:3 //物件池最大容量
            );        
    }    

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab); //用本地物件設定生成的物件
        bullet.SetPool(bulletPool); //設定生成的物件屬於bulletPool物件池
        return bullet; //回傳本地物件
    }

    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true); //設定物件為可見
        bullet.transform.position = muzzle.transform.position; //設定物件的座標為Launcher的座標
        bullet.transform.forward = muzzle.transform.forward; //設定bullet的世界Z軸座標
    }

    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false); //設定物件為不可見
    }

    private void OnDestroyObj(Bullet bullet)
    {
        Destroy(bullet.gameObject); //摧毀物件
    }    

    public virtual void Fire()
    {
        bulletPool.Get(); //創建物件時，從物件池拿取物件
    }
}
