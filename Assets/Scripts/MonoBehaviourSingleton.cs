using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourSingleton : MonoBehaviour
{
    void Awake()
    {
        int gameStatusCount = FindObjectsOfType(GetType()).Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
            DontDestroyOnLoad(gameObject);
    }
}
