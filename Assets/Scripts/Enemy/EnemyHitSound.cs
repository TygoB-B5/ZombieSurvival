using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class EnemyHitSound : MonoBehaviour
{
    public AudioSource aud;

    private void Awake()
    {
        GetComponentInParent<EnemyDetectHit>().OnHit += PlaySound;
    }

    private void PlaySound()
    {
        StartCoroutine(PlaySoundWithDelay());
    }

    private IEnumerator PlaySoundWithDelay()
    {
        yield return new WaitForSeconds(0.2f);
        aud.pitch = Random.Range(0.9f, 1.1f);
        aud.Play();
    }
}
