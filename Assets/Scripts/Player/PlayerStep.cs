using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    private AudioSource aud;
    public AudioClip[] step = default;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();
        FindObjectOfType<PlayerBob>().OnBobOnFloor += PlayStep;
    }

    private void PlayStep()
    {
        aud.PlayOneShot(step[Random.Range(0, step.Length)], aud.volume);
    }
}
