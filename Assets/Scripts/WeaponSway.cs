using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{

    [SerializeField] private Transform Tower;
    [SerializeField] private Transform Gun;
    /* [SerializeField] private float towerSpeed;
    [SerializeField] private float gunSpeed; */
    [SerializeField] private Camera cam;

    /* private float towerAngle;
    private float gunAngle; */

    
    void FixedUpdate()
    {
        RotateTower();
        RotateGun();
    }

    void RotateTower()
    {
        Quaternion cameraRotation = cam.transform.rotation;
        /* towerAngle = cameraRotation.eulerAngles.y;
        towerAngle = Mathf.Clamp(towerAngle, -90, 90); */
        Tower.localRotation = Quaternion.Euler(0, cameraRotation.eulerAngles.y, 0);
    }

    void RotateGun()
    {
        Quaternion cameraRotation = cam.transform.rotation;
        /* gunAngle = cameraRotation.eulerAngles.x;
        gunAngle = Mathf.Clamp(gunAngle, -45, 45); */
        Gun.localRotation = Quaternion.Euler(cameraRotation.eulerAngles.x, 0,0); 
    }
}
