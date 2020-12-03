using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager enemyManager { get; private set; }
    public static List<Enemy> enemies = new List<Enemy>();

    [SerializeField] private float distance = default;
    [SerializeField] private int enemiesToStart = default;
    [SerializeField] private int enemiesToAddPerWave = default;

    public GameObject enemy;
    private Transform player;
    private int enemiesToAdd;

    private void Awake()
    {
        if (enemyManager == null)
            enemyManager = this;
        else
            Destroy(gameObject, 0);

        player = GameObject.FindWithTag("Player").transform;
    }

    private void Start()
    {
        enemiesToAdd = enemiesToStart;
        SpawnEnemy(enemiesToAdd);
    }

    private void Update()
    {
        if (enemies.Count <= 8)
        {
            enemiesToAdd += enemiesToAddPerWave;
            SpawnEnemy(enemiesToAdd);
        }
    }

    private void SpawnEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = GetRandomPos();

            while(Vector3.Distance(pos, player.transform.position) < distance / 1.5f)
                pos = GetRandomPos();

            if(Physics.Raycast(pos + transform.up * 50, -transform.up, out RaycastHit hit, Mathf.Infinity))
                Instantiate(enemy, hit.point + transform.up * 2, Quaternion.Euler(0, 0, 0));
        }
    }

    private Vector3 GetRandomPos()
    {
        Vector3 pos = new Vector3(
    Random.Range(player.position.x - distance, player.position.x + distance)
    , 0,
    Random.Range(player.position.z - distance, player.position.z + distance));
        return pos;
    }
}
