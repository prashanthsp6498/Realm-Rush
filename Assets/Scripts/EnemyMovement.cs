using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    PathFinder paths;
    void Start()
    {
        paths = FindObjectOfType<PathFinder>();
        var path = paths.StartToEndPath();
        StartCoroutine(ProcessWayPoints(path));
    }

    IEnumerator ProcessWayPoints(List<WayPoints> path)
    {
        foreach(WayPoints point in path)
        {
            transform.position = point.transform.position;
            yield return new WaitForSeconds(2f);
        }
    }
}
