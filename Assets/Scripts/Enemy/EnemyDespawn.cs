using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    [SerializeField] private float minHeightBeforeDespawn = default;

    void Update()
    {
        if (transform.position.y < minHeightBeforeDespawn)
            Destroy(gameObject);
    }
}
