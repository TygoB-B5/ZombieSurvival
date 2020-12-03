using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    private GunShoot gunShoot;
    private Camera cam;
    public GameObject bulletHolePrefab;


    private void Awake()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        gunShoot = FindObjectOfType<GunShoot>();
        gunShoot.OnShootGun += Shoot;
    }

    private void Shoot()
    {
        GameObject bulletImpact = Instantiate(bulletHolePrefab, gunShoot.hit.point, Quaternion.LookRotation(gunShoot.hit.point - cam.transform.position));
        bulletImpact.transform.Rotate(0, 90, 0);
        bulletImpact.transform.parent = gunShoot.hit.transform;
        Destroy(bulletImpact, 5);
    }
}
