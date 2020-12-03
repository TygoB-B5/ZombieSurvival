using UnityEngine;
using System;

public class PlayerScore : MonoBehaviour
{
    private int _score;
    public int score
    {
        get { return _score; }
        set { _score = Mathf.Clamp(value, 0, 100000000); OnScoreUpdate(); }
    }

    public event Action OnScoreUpdate = delegate { };
}
