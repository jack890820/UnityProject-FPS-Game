    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestSubjectCode
{
    public class ObjectRaycast : MonoBehaviour
    {
        public static ObjectRaycast instance;
        [SerializeField] public float radius = 10f;
        [SerializeField] public Transform ibObject;
        [SerializeField] Renderer ibObjectRender;
        [SerializeField] Material redMaterial;
        [SerializeField] Material ibMaterial;

        private void Awake() 
        {
            instance = this;    
        }

        void Start()
        {
            
        }

        void Update()
        {
            SearchObject();
        }

        public void SearchObject()
        {
            Collider[] colliders = Physics.OverlapSphere(ibObject.position, radius, LayerMask.GetMask("Player"));//碰到Layer為Player的物件時，colliders.Length會+1    

            if (colliders.Length <= 0) 
            {
                ibObjectRender.material = ibMaterial;
                return;            
            }        
            
            if (Raycast.instance.interactableText.activeSelf == true)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    ibObjectRender.material = redMaterial;
                }
            }         
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(ibObject.position, radius);
        }
    }
}