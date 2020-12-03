using UnityEngine;
using System;
using System.Collections;

public class GunShoot : MonoBehaviour
{
    private PlayerInput playerInput;
    private GunShotMode gunShotMode;
    private GunSpread gunSpread;
    private GunAmmo gunAmmo;

    private Camera player;
    private bool hasReset = true;
    private bool hasResetBurst = true;

    public bool canShoot { get; set; } = true;
    public RaycastHit hit { get; private set; }

    [SerializeField] private float fireRate = default;

    public event Action OnShootGun = delegate { };

    private void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        gunShotMode = FindObjectOfType<GunShotMode>();
        gunAmmo = FindObjectOfType<GunAmmo>();
        gunSpread = GetComponent<GunSpread>();
        player = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (gunAmmo.ammo <= 0 || !canShoot)
            return;

        GetShootMode();
    }

    private void GetShootMode()
    {
        if (gunShotMode == null)
            SingleShot();

        switch (gunShotMode.gunMode)
        {
            case GunShotMode.GunMode.Semi:
                SingleShot();
                break;

            case GunShotMode.GunMode.Auto:
                AutoShot();
                break;

            case GunShotMode.GunMode.Burst:
                BurstShot();
                break;
        }
    }

    private void SingleShot()
    {
        if (playerInput.SingleShoot && !playerInput.Sprint && hasReset)
        {
            Shoot();
            OnShootGun();
            StartCoroutine(ResetTimer());
        }
    }

    private void AutoShot()
    {
        if (playerInput.Shoot && !playerInput.Sprint && hasReset)
        {
            Shoot();
            OnShootGun();
            StartCoroutine(ResetTimer());
        }
    }

    private void BurstShot()
    {
        if (playerInput.SingleShoot && !playerInput.Sprint && hasResetBurst)
        {
            StartCoroutine(TripleFire());
        }
    }

    private IEnumerator TripleFire()
    {
        if (!hasResetBurst)
            yield return null;

        hasResetBurst = false;

        Shoot();
        OnShootGun();
        yield return new WaitForSeconds(fireRate / 2f);
        Shoot();
        OnShootGun();
        yield return new WaitForSeconds(fireRate / 2f);
        Shoot();
        OnShootGun();
        yield return new WaitForSeconds(fireRate * 2);

        hasResetBurst = true;
    }

    private IEnumerator ResetTimer()
    {
        if (!hasReset)
            yield return null;

        hasReset = false;
        yield return new WaitForSeconds(fireRate);
        hasReset = true;
    }

    private void Shoot()
    {
        //getspreadvector
        Vector2 spreadVector = gunSpread.Spread();

        //get ray direction with spread
        Vector3 dir = player.transform.forward + player.transform.right * spreadVector.x + player.transform.up * spreadVector.y;

        //shoot ray
        if (Physics.Raycast(player.transform.position + player.transform.forward, dir, out RaycastHit hit, 400f))
        {
            this.hit = hit;
            if (this.hit.collider.GetComponent<EnemyDetectHit>() != null)
            {
                this.hit.collider.GetComponent<EnemyDetectHit>().Hit();
                FindObjectOfType<PlayerScore>().score += 10;
            }
        }
    }
}
