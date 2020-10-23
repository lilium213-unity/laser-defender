using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePath : MonoBehaviour
{
    List<Transform> waypoints = new List<Transform>();


    public List<Transform> GetWaypoints()
    {
        if(waypoints.Count == 0)
        {
            foreach(Transform child in transform)
            {
                waypoints.Add(child);
            }
        }

        return waypoints;
    }
}
