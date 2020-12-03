using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartBeat : MonoBehaviour
{
    public AudioSource heartBeat;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        heartBeat.volume = Mathf.Sin((playerHealth.maxHealth / (float)playerHealth.health) / playerHealth.maxHealth * 2.5f) * 3 - 0.24f;
    }
}