using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestSubjectCode
{
    public class Destructible : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}