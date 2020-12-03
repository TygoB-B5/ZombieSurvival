using UnityEngine;
using System.Collections.Generic;

public class MedkitManager : MonoBehaviour
{
    public static MedkitManager enemyManager { get; private set; }
    public static List<Medkit> medkits = new List<Medkit>();

    [SerializeField] private float distance = default;
    private Transform player;

    public GameObject medkit;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;

        if (enemyManager == null)
            enemyManager = this;
        else
            Destroy(gameObject, 0);
    }

    private void Update()
    {
        if (medkits.Count == 0)
            SpawnMedkits();
    }

    private void SpawnMedkits()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos = GetRandomPos();

            while (Vector3.Distance(pos, player.transform.position) < distance / 1.5f)
                pos = GetRandomPos();

            if (Physics.Raycast(pos + transform.up * 50, -transform.up, out RaycastHit hit, Mathf.Infinity))
                Instantiate(medkit, hit.point + transform.up * 0.1f, Quaternion.Euler(-90, 0, 0));
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
