using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject thisEnemy { get; private set; }

    private void Awake()
    {
        thisEnemy = this.gameObject;
    }

    private void Start()
    {
        EnemyManager.enemies.Add(this);
    }

    private void OnDestroy()
    {
        EnemyManager.enemies.Remove(this);
    }
}
