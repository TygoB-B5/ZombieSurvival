using UnityEngine;

[RequireComponent(typeof(EnemyDetectHit))]
public class EnemyDie : MonoBehaviour
{
    [SerializeField] private float timeBeforeDespawn = default;

    private void Awake()
    {
        GetComponent<EnemyDetectHit>().OnHit += Die;
    }

    private void Die()
    {
        Destroy(GetComponent<EnemyFollow>());
        Destroy(GetComponent<EnemyAttack>());
        Destroy(GetComponent<Collider>());
        Destroy(gameObject, timeBeforeDespawn);
    }
}
