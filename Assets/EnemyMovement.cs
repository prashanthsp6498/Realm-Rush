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
            print(point.transform.position.x + point.transform.position.y);
            transform.position = point.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        
    }
}
