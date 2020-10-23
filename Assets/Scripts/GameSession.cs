using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviourSingleton
{
    public int Score { get; private set; } = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int points)
    {
        Score += points;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
