using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] WayPoints startPoint, endPoint;
    Dictionary<Vector2Int, WayPoints> grid = new Dictionary<Vector2Int, WayPoints>();

    void Start()
    {
        LoadBlocks();
    }

    private void LoadBlocks()
    {
        WayPoints[] waypoints = FindObjectsOfType<WayPoints>();
        foreach (WayPoints waypoint in waypoints)
        {
            bool isOverlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (isOverlapping)
            {
                Debug.Log("Skipping Blocks : " + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                if (waypoint == startPoint)
                    waypoint.SetTopColor(Color.green);
                if (waypoint == endPoint)
                    waypoint.SetTopColor(Color.red);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}