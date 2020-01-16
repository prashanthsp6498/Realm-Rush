using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor: MonoBehaviour
{
    WayPoints wayPoints;

    private void Awake()
    {
        wayPoints = GetComponent<WayPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        SnapGrid();
        AddLabel();
    }

    private void AddLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string label = wayPoints.GetGridPos().x + "," + wayPoints.GetGridPos().y;
        textMesh.text = label;
        gameObject.name = label;
    }

    private void SnapGrid()
    {
        transform.position = new Vector3(
            wayPoints.GetGridPos().x,
            0f,
            wayPoints.GetGridPos().y
        );
    }
}
