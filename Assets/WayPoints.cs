using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WayPoints : MonoBehaviour
{
    public bool isExplored = false;

    [SerializeField] public WayPoints exploredFrom;
    const int gridSize = 1;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
            Mathf.RoundToInt(transform.position.z / gridSize) * gridSize
        );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer top = transform.Find("Top").GetComponent<MeshRenderer>();
        top.material.color = color;
    }
}
