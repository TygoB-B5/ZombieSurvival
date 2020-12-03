using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlare : MonoBehaviour
{
    public GameObject flare;

    [SerializeField] private float flareLifetime = default;

    private void Awake()
    {
        FindObjectOfType<GunShoot>().OnShootGun += Shoot;
    }

    private void Shoot()
    {
        StartCoroutine(ShowFlare());
    }

    private IEnumerator ShowFlare()
    {
        flare.SetActive(true);
        yield return new WaitForSeconds(flareLifetime);
        flare.SetActive(false);
    }
}
