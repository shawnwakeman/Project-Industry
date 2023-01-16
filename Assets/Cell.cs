using UnityEngine;

public class Cell
{
    public Vector2 worldPos;
    public Vector2Int gridIndex;


    public Cell(Vector2 _worldpos, Vector2Int _gridindex)  
    {

        worldPos = _worldpos;
        gridIndex = _gridindex;

    }
}