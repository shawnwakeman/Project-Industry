using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{

    public Vector2Int gridSize;
    public float cellRadius = 0.5f;
    public Grid currentGrid;
    public Cell destinationCell;
    public GridDebug gridDebug;

    [HideInInspector]
    public Vector3 worldPosition;

    public void InitializeGrid()
    {

        currentGrid = new Grid(cellRadius, gridSize);
        currentGrid.CreateGrid();
    }

    private void Start()
    {
        InitializeGrid();
        gridDebug.SetFlowField(currentGrid);
    }
}