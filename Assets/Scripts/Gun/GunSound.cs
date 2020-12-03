using UnityEngine;

public class GunSound : MonoBehaviour
{
    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        FindObjectOfType<GunShoot>().OnShootGun += Shoot;
    }

    private void Shoot()
    {
        aud.Play();
    }
}
