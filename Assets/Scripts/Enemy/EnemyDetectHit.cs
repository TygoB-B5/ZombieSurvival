using System;
using UnityEngine;

public class EnemyDetectHit : MonoBehaviour
{
    public event Action OnHit = delegate { };

    public void Hit()
    {
        OnHit();
    }
}
