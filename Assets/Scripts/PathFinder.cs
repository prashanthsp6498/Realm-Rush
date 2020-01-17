using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathFinder : MonoBehaviour
{
    [SerializeField] WayPoints startPoint, endPoint;
    Dictionary<Vector2Int, WayPoints> grid = new Dictionary<Vector2Int, WayPoints>();

    Queue<WayPoints> queue = new Queue<WayPoints>();

    List<WayPoints> pathList = new List<WayPoints>();

    WayPoints searchCenter;

    [SerializeField] bool isRunning = true;

    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.left,
        Vector2Int.right,
        Vector2Int.down
    };

    public List<WayPoints> StartToEndPath()
    {
        if (pathList.Count == 0)
        {
            LoadBlocks();
            PathSearch();
            FindParent();
        }
        return pathList;
    }

    private void FindParent()
    {
        var previous = endPoint;
        previous.isPlacable = false;
        while (previous != startPoint)
        {
            previous.isPlacable = false;
            pathList.Add(previous);
            previous = previous.exploredFrom;
        }
        startPoint.isPlacable = false;
        pathList.Add(startPoint);
        pathList.Reverse();
    }

    private void PathSearch()
    {
        queue.Enqueue(startPoint);
        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;
        }
    }


    private void HaltIfEndFound(WayPoints searchCenter)
    {
        if (searchCenter == endPoint)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours(WayPoints searchCenter)
    {
        if (!isRunning) { return; }

        foreach (Vector2Int direction in directions)
        {
            Vector2Int NewNeighbours = direction + searchCenter.GetGridPos();
            try
            {
                QueueNewNeighbours(NewNeighbours);
            }
            catch
            {
                //
            }
       }
    }

    private void QueueNewNeighbours(Vector2Int NewNeighbours)
    {
        WayPoints neighbours = grid[NewNeighbours];
        if (neighbours.isExplored || queue.Contains(neighbours))
        {
           // 
        }
        else
        {
            neighbours.SetTopColor(Color.blue);
            queue.Enqueue(neighbours);
            neighbours.exploredFrom = searchCenter;
        }
    }

    private void LoadBlocks()
    {
        WayPoints[] waypoints = FindObjectsOfType<WayPoints>();
        foreach (WayPoints waypoint in waypoints)
        {
            bool overlapping = grid.ContainsKey(waypoint.GetGridPos());
            if (!overlapping)
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                if (waypoint == startPoint)
                    waypoint.SetTopColor(Color.green);
                if (waypoint == endPoint)
                    waypoint.SetTopColor(Color.red);
            }
        }
    }
}
