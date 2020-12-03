using UnityEngine;

public class EnemyAmbientSound : MonoBehaviour
{
    public AudioSource aud;

    private void Start()
    {
        aud.time = Random.Range(0, aud.clip.length);
        aud.pitch = Random.Range(0.9f, 1.1f);
    }
}
