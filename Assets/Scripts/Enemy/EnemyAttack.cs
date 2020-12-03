using UnityEngine;
using System;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float resetAttackTime = default;
    [SerializeField] private float minimumEngagingDistance = default;
    [SerializeField] private int damage = default;

    private float currentDistance;
    private Transform player;
    public bool hasShot { get; private set; } = false;

    public event Action OnShoot = delegate { };

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (hasShot)
            return;

        currentDistance = Vector3.Distance(transform.position, player.position);

        if (currentDistance < minimumEngagingDistance)
        {
            OnShoot();
            FindObjectOfType<PlayerHealth>().health -= damage;
            StartCoroutine(ResetAttack());
            hasShot = true;
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(resetAttackTime);
        hasShot = false;
    }
}
