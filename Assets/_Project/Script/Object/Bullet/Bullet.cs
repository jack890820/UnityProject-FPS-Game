using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace TestSubjectCode
{
    public class Bullet : MonoBehaviour
    {
        //摘要
        //  子彈組件

        [SerializeField] float force, lifeTime; //物件速度
        [SerializeField] Rigidbody rb;
        private IObjectPool<Bullet> bulletPool; //物件池

        private void Start() 
        {
            rb = GetComponent<Rigidbody>();               
        }

        public void SetPool(IObjectPool<Bullet> pool) //設定物件池為變數物件池pool
        {
            bulletPool = pool;
        }

        private void Update() 
        {
            rb.velocity = transform.forward * force; //bullet的動能        
        }    

        void OnBecameInvisible() 
        {
            bulletPool.Release(this); //回收物件
        }
    }
}