using UnityEngine;

public class GunSpread : MonoBehaviour
{
    private PlayerEngine playerEngine;

    [SerializeField] private Vector2 staticSpread = default;
    [SerializeField] private Vector2 spread = default;
    [SerializeField] private float speedToSpreadMultiplier = default;

    private void Awake()
    {
        playerEngine = FindObjectOfType<PlayerEngine>();
    }

    public Vector2 Spread()
    {
        float movement = playerEngine.currentPlayerSpeed * speedToSpreadMultiplier;
        float randX = Random.Range(-staticSpread.x, staticSpread.x) + (movement * Random.Range(-spread.x, spread.x)) * 0.1f;
        float randY = Random.Range(-staticSpread.y, staticSpread.y) + (movement * Random.Range(-spread.y, spread.y)) * 0.1f;
        return new Vector2(randX, randY);
    }
}
