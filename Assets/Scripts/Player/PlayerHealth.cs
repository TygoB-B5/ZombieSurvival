using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 20;
    public int maxHealth = 20;

    public int health {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, maxHealth);  UpdateHealth(); }
    }

    public event Action OnDie = delegate { };
    public event Action OnUpdateHealth = delegate { };

    public void Start()
    {
        health = health;
    }

    public void UpdateHealth()
    {
        OnUpdateHealth();

        if (health <= 0)
            OnDie();
    }
}
