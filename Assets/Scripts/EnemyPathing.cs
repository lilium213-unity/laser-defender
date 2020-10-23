using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    public WaveConfig WaveConfig { get; set; }
    List<Transform> waypoints = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        waypoints = WaveConfig.GetWaypoints();
        transform.position = waypoints.First<Transform>().position;
        waypoints.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypoints.Count > 0)
        {
            Vector2 nextWaypoint = waypoints.First<Transform>().position;
            transform.position = Vector2.MoveTowards(transform.position, nextWaypoint, WaveConfig.MoveSpeed * Time.deltaTime);
            if (transform.position.Equals(nextWaypoint))
                waypoints.RemoveAt(0);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
