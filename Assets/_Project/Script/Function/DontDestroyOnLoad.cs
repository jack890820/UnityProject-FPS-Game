using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestSubjectCode
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        [SerializeField] GameObject dontDestroyOnLoadPrefab = null;

        static bool hasSpawned = false;

        private void Awake() 
        {
            if(hasSpawned) return;

            SpawnDontDestroyOnLoadObjects();
            
            hasSpawned = true;
        }

        private void SpawnDontDestroyOnLoadObjects()
        {
            GameObject dontDestroyOnLoadObject = Instantiate(dontDestroyOnLoadPrefab);
            DontDestroyOnLoad(dontDestroyOnLoadObject);
        }
    }
}
