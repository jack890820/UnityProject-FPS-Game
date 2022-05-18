using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
