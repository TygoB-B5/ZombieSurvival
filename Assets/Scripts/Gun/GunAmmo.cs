using System.Collections;
using UnityEngine;
using System;

public class GunAmmo : MonoBehaviour
{
    public int ammo { get; private set; }
    public AudioSource reloadSound;
    private PlayerInput playerInput;

    [SerializeField] private float reloadTime = default;
    [SerializeField] private int maxAmmoCapacity = default;

    public event Action OnUpdateAmmo = delegate { };

    private void Awake()
    {
        FindObjectOfType<GunShoot>().OnShootGun += ShotBullet;
        playerInput = FindObjectOfType<PlayerInput>();
        ammo = maxAmmoCapacity;
    }

    private void ShotBullet()
    {
        if(ammo > 0)
            ammo--;

        OnUpdateAmmo();
    }

    private void Update()
    {
        if (playerInput.Reload)
            StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        GetComponentInParent<GunShoot>().canShoot = false;
        reloadSound.Play();
        yield return new WaitForSeconds(reloadTime);
        GetComponentInParent<GunShoot>().canShoot = true;
        ammo = maxAmmoCapacity;
        OnUpdateAmmo();
    }
}
