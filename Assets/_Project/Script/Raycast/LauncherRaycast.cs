using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherRaycast : MonoBehaviour
{
    [SerializeField] float rayRange = 30f;
    [SerializeField] Transform rayTransform;
    Ray launcherRay;    

    private void Start() 
    {
        Ray launchgerRay = new Ray(rayTransform.transform.position, rayTransform.transform.forward * rayRange);
    }
    
    void LateUpdate()
    {
        LauncherRay();
    }

    public void LauncherRay()
    {        
        RaycastHit hit;
        Debug.DrawRay(rayTransform.transform.position, rayTransform.transform.forward * rayRange);

        if(Physics.Raycast(launcherRay, out hit, rayRange, LayerMask.GetMask("Enemy")))
        {
            return;
        }
    }
}
