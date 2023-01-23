using UnityEngine;

public class Cell
{
    public Vector2 worldPos;
    public Vector2Int gridIndex;
    public bool cellOcupided;
    public GameObject currentconveyor;
    public Vector2 conveyorVelocity = new Vector2(0,0);
    public Vector2 endingVelocity;
    public bool turnPeice;
    
    public enum conveyorVelocitys
    {
        
    }


    public Cell(Vector2 _worldpos, Vector2Int _gridindex)  
    {

        worldPos = _worldpos;
        gridIndex = _gridindex;
        cellOcupided = false;
    }

    public void SetVelocity(Vector2 _conveyorVelocity)
    {
        conveyorVelocity = _conveyorVelocity;
    }

    public void SetTurnVelocity(Vector3 start, Vector3 end)
    {
        turnPeice = true;
        conveyorVelocity = start;
        endingVelocity = end;
    }
}