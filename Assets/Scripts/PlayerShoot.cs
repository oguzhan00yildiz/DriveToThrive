using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey;
    [SerializeField] private GunData gunData;

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            shootInput?.Invoke();
        }

        if(Input.GetKeyDown(reloadKey) || gunData.currentAmmo<=0)
        {
            reloadInput?.Invoke();
        }
    }
}
