using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] float gameOverDelay = 2f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Starting Scene");
    }

    public void LoadGameOver()
    {
        StartCoroutine(LoadDelayedGameOver());
    }

    private IEnumerator LoadDelayedGameOver()
    {
        Debug.Log("Waiting");
        yield return new WaitForSeconds(gameOverDelay);
        Debug.Log("Loading now");
        SceneManager.LoadScene("Game Over");
    }

    public void LoadGame()
    {
        FindObjectOfType<GameSession>().ResetGame();
        Debug.Log("Clicked start game");
        SceneManager.LoadScene("Core");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
