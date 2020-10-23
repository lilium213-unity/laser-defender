using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [field: SerializeField] public GameObject EnemyPrefab { get; private set; }
    [field: SerializeField] public GameObject PathPrefab { get; private set; }
    [field: SerializeField] public float TimeBetweenWaves { get; private set; } = 0.5f;
    [field: SerializeField] public float SpawnRandomFactor { get; private set; } = 0.3f;
    [field: SerializeField] public int NumberOfEnemies { get; private set; } = 5;
    [field: SerializeField] public float MoveSpeed { get; private set; } = 2f;  

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();

        foreach(Transform child in PathPrefab.transform)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }
}
