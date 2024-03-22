using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public GunData gunData;
    [SerializeField] private Transform muzzle;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem muzzleFlash;
    static public Gun instance;

    //[SerializeField] private Image crosshairImage;
    //[SerializeField] private LayerMask hitLayerMask;
    private float timeSinceLastShoot;

    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReloading;

        gunData.currentAmmo = 50;
        instance = this;
    }
    private void Update()
    {
        timeSinceLastShoot += Time.deltaTime;

        Debug.DrawRay(muzzle.position, muzzle.forward);


    }
    //!gunData.reloading
    private bool CanShoot() =>  timeSinceLastShoot > 1f / (gunData.fireRate / 60f);
    public void Shoot()
    {
        if(gunData.currentAmmo > 0)
        {
            if(CanShoot())
            {
                Debug.Log("Shoot can shoot");
                if(Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hitInfo, gunData.maxDistance))
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
        animator.SetTrigger("Shoot");
        muzzleFlash.Play();

        FindObjectOfType<AudioManager>().Play("ShootTurret");
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
        FindObjectOfType<AudioManager>().Play("ReloadTurret");
        yield return new WaitForSeconds(gunData.reloadTime);

        gunData.currentAmmo = gunData.magSize;

        gunData.reloading = false;
    }
}
