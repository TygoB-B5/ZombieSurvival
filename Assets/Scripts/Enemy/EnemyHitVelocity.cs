using UnityEngine;

public class EnemyHitVelocity : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<EnemyDetectHit>().OnHit += AddVeclocity;
    }

    private void AddVeclocity()
    {
        if (!GetComponent<Rigidbody>())
            gameObject.AddComponent<Rigidbody>();

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.mass = 0.1f;
        GameObject player = GameObject.FindWithTag("Player").GetComponentInChildren<Camera>().gameObject;
        rb.AddForce(player.transform.forward * 1, ForceMode.Impulse);
    }
}
