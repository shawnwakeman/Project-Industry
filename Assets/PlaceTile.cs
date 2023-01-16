using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTile : MonoBehaviour
{
    [SerializeField] GridController gridController;
    [SerializeField] GameObject conveyorBelt;
    [SerializeField] GameObject converyorTurn;
    [SerializeField] GameObject converyorTurn2;
    [SerializeField] GameObject woodChopper;
    [SerializeField] GameObject packager;
    [SerializeField] GameObject entrance;
    [SerializeField] GameObject exit;
    
    Cell targetCell;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetKeyDown(KeyCode.W))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(conveyorBelt, targetCell.worldPos + new Vector2(.054f, .021f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 90));

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(conveyorBelt, targetCell.worldPos + new Vector2(.014f, -.074f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(conveyorBelt, targetCell.worldPos + new Vector2(-.03f, .068f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -180));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(conveyorBelt, targetCell.worldPos + new Vector2(-.078f, -.028f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -90));
        }

        else if (Input.GetKeyDown(KeyCode.U))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(converyorTurn, targetCell.worldPos + new Vector2(-.125f, .1232f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -270));
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(converyorTurn, targetCell.worldPos + new Vector2(.118f, .107f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(converyorTurn, targetCell.worldPos + new Vector2(.11f, -.128f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -90));
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(converyorTurn, targetCell.worldPos + new Vector2(-.134f, -.115f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -180));
        }


        else if (Input.GetKeyDown(KeyCode.I))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(converyorTurn2, targetCell.worldPos + new Vector2(-.18f, .12f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(converyorTurn2, targetCell.worldPos + new Vector2(.106f, .171f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -90));
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(converyorTurn2, targetCell.worldPos + new Vector2(.155f, -.123f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -180));
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(converyorTurn2, targetCell.worldPos + new Vector2(-.132f, -.178f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -270));
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(woodChopper, targetCell.worldPos + new Vector2(.0805f, .9293f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(packager, targetCell.worldPos + new Vector2(1.082f,.919f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(entrance, targetCell.worldPos + new Vector2(-.7f,0), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(exit, targetCell.worldPos + new Vector2(.9f,0), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
        }




          

    }
}
