﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WayPoints : MonoBehaviour
{
    public bool isExplored = false;
    public bool isPlacable= true;
    [SerializeField] Tower towerPrefab;

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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacable)
            {
                Instantiate(towerPrefab, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
