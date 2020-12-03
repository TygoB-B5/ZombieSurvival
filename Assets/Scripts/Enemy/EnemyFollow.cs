using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float movementSpeed = default;
    [SerializeField] private float rotationSpeed = default;
    [SerializeField] private float maxSpeedToAddOnInstantiate = default;

    private EnemyAttack enemyAttack;

    private Transform player;

    private void Awake()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        player = GameObject.FindWithTag("Player").transform;
        movementSpeed += Random.Range(0, maxSpeedToAddOnInstantiate);
    }

    void Update()
    {
        if (enemyAttack.hasShot)
            return;
        
        Vector3 dir = player.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
