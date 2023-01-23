using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    // Start is called before the first frame update
    public Cell[,] grid {get; private set;}
    public Vector2Int gridSize {get; private set;}
    public float cellRadius {get; private set;}
    private float cellDiameter; 

    public Grid(float _cellRadius, Vector2Int _gridSize)
    {
        cellRadius = _cellRadius;
        gridSize = _gridSize;
        cellDiameter = cellRadius * 2f;
        

    }

    public void CreateGrid()
    {
        grid = new Cell[gridSize.x, gridSize.y];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector2 worldPos = new Vector2(cellDiameter * x + cellRadius, cellDiameter * y + cellRadius);
                grid[x,y] = new Cell(worldPos, new Vector2Int(x,y));
            }
        }

        SetEdgeVelocitys();
    }

    private void SetEdgeVelocitys()
    {
        for (int i = 0; i < gridSize.y; i++)
        {
            grid[0, i].SetVelocity(new Vector2(1, 0));
            grid[0, i].cellOcupided = true;
        }
        for (int i = 0; i < gridSize.y; i++)
        {
            grid[gridSize.x -1, i].SetVelocity(new Vector2(1, 0));
            grid[gridSize.x - 1, i].cellOcupided = true;

        }
    }
    

    public Cell GetCellFromWorldPos(Vector3 worldPos )
    {
        
        float x = worldPos.x;
        float y = worldPos.y;

        x = x/cellDiameter;
        y = y/cellDiameter;

        x = Mathf.Floor(x);
        y = Mathf.Floor(y);
        return grid[(int)x, (int)y];

    }

 

}
