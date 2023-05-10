using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    private Transform turretBarrel;
    
    void FixedUpdate()
    {
        Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        //Ray turreten çıksın crosshair ona göre hareket etsin
    
        if(Physics.Raycast(rayOrigin, out hitInfo))
        {
            if(hitInfo.collider != null)
            {
                //direction = destination - source
                Vector3 direction = hitInfo.point - turretBarrel.position;
                turretBarrel.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
