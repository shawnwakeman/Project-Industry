using UnityEditor;
using UnityEngine;
 

public class GridDebug : MonoBehaviour
{
    public GridController gridController;
    public bool displayGrid;
 
 
    private Vector2Int gridSize;
    private float cellRadius;
    private Grid currentGrid;
 
    private Sprite[] ffIcons;

    private void Start()
    {
        ffIcons = Resources.LoadAll<Sprite>("Sprites/FFicons");
        
    }
 
    public void SetFlowField(Grid newFlowField)
    {
        currentGrid = newFlowField;
        cellRadius = newFlowField.cellRadius;
        gridSize = newFlowField.gridSize;
    }

    private void OnDrawGizmos()
    {
        if (displayGrid)
        {
            if (currentGrid == null)
            {
                DrawGrid(gridController.gridSize, Color.yellow, gridController.cellRadius);
              
            }
            else
            {
                DrawGrid(gridSize, Color.green, cellRadius);
            }
        }
    }


    private void DrawGrid(Vector2Int drawGridSize, Color drawColor, float drawCellRadius)
    {
        Gizmos.color = drawColor;
        for (int x = 0; x < drawGridSize.x; x++)
        {
            for (int y = 0; y < drawGridSize.y; y++)
            {
                Vector3 center = new Vector3(drawCellRadius * 2 * x + drawCellRadius, drawCellRadius * 2 * y + drawCellRadius, 0);
                Vector3 size = Vector3.one * drawCellRadius * 2;
                Gizmos.DrawWireCube(center, size);
            }
        }
    }
}