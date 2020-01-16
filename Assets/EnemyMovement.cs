using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoints> path;

    void Start()
    {
        StartCoroutine(ProcessWayPoints());
    }

    IEnumerator ProcessWayPoints()
    {
        foreach(WayPoints point in path)
        {
            transform.position = point.transform.position + Vector3.up;
            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        
    }
}
