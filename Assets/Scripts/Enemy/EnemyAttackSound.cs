using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyAttackSound : MonoBehaviour
{
    public AudioSource aud;

    private void Awake()
    {
        GetComponentInParent<EnemyAttack>().OnShoot += PlayShot;
    }

    private void PlayShot()
    {
        aud.Play();
    }
}
