using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GunData gunData;
    [SerializeField] private Transform muzzle;
    //[SerializeField] private Image crosshairImage;
    //[SerializeField] private LayerMask hitLayerMask;
    private float timeSinceLastShoot;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReloading;
    }
    private void Update()
    {
        timeSinceLastShoot += Time.deltaTime;

        Debug.DrawRay(muzzle.position, muzzle.forward);

       
    }
    
    private bool CanShoot() => !gunData.reloading && timeSinceLastShoot > 1f / (gunData.fireRate / 60f);
    public void Shoot()
    {
        if(gunData.currentAmmo > 0)
        {
            if(CanShoot())
            {
                if(Physics.Raycast(muzzle.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    Debug.Log(hitInfo.transform.name);
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.TakeDamage(gunData.damage);
                }

                gunData.currentAmmo--;
                timeSinceLastShoot = 0;
                OnGunShoot();
            }
        }
    }
    private void OnGunShoot()
    {
        //for anims and effects
    }

    public void StartReloading()
    {
        if(!gunData.reloading)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }
}
