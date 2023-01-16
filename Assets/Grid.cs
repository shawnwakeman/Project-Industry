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
    }

    // private Cell GetCellAtRelativePos(Vector2Int orignPos, Vector2Int relativePos)
    // {
    //     Vector2Int finalPos = orignPos + relativePos;
 
    //     if (finalPos.x < 0 || finalPos.x >= gridSize.x || finalPos.y < 0 || finalPos.y >= gridSize.y)
    //     {
    //         return null;
    //     }
 
    //     else { return grid[finalPos.x, finalPos.y]; }
    // }
    

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
