using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private int _score;

    public void Die()
    {
        GameOver?.Invoke();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void ResetScore()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}
