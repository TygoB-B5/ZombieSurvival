using UnityEngine;
using System.Collections;

public class MedkitSound : MonoBehaviour
{
    public AudioSource aud;

    private void Awake()
    {
        GetComponentInParent<MedkitDetectPickup>().OnPickupMedkit += PlaySound;
    }

    private void PlaySound(GameObject player)
    {
        aud.pitch = Random.Range(0.9f, 1.1f);
        aud.Play();
    }
}
