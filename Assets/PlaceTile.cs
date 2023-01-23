using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTile : MonoBehaviour
{
    [SerializeField] GridController gridController;
    [SerializeField] GameObject conveyorBelt;
    public GameObject converyorTurn;
    [SerializeField] GameObject converyorTurn2;
    [SerializeField] GameObject woodChopper;
    [SerializeField] GameObject packager;
    [SerializeField] GameObject entrance;
    [SerializeField] GameObject exit;

    public enum prefabEnum
    {

        conveyorBelt,
        converyorTurn,
        converyorTurn2,
        woodChopper,
        packager,
        entrance,
        exit,



    }
    Cell targetCell;

    Vector3 worldPosition;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        if (Input.GetKeyDown(KeyCode.W))
        {
            InitializePart("uu");

        }
        else if (Input.GetKey(KeyCode.D))
        {
            InitializePart("rr");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            InitializePart("ll");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
             InitializePart("dd");
        }

        else if (Input.GetKeyDown(KeyCode.U))
        {
            InitializePart("ur");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            InitializePart("rd");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            InitializePart("dl");
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            InitializePart("lu");
        }


        else if (Input.GetKeyDown(KeyCode.I))
        {
           InitializePart("ld");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            InitializePart("ul");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            InitializePart("ru");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            InitializePart("dr");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(woodChopper, targetCell.worldPos + new Vector2(.0105f, .9293f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
            InitializePart("rr");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);
            Instantiate(packager, targetCell.worldPos + new Vector2(1.0f,.919f), 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0));
            InitializePart("rr");
            worldPosition.x += 2;
            InitializePart("ru");
            worldPosition.y += 2;
            InitializePart("ur");
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


    public struct ConveyorInfo
    {
        public Vector2 placementOffset;
        public Vector2 conveyorVelocity;
        public int rotation;
        public prefabEnum prefab;
        public Vector2 finishingVelocity;
        public ConveyorInfo(Vector2 _placementOffset, Vector2 _conveyorVelocity, int _rotation, prefabEnum _prefab, Vector2 _finishingVelocity)
        {
            this.placementOffset = _placementOffset;
            this.conveyorVelocity = _conveyorVelocity;
            this.rotation = _rotation;
            this.prefab = _prefab;
            this.finishingVelocity = _finishingVelocity;

        }
    }

    IDictionary<string, ConveyorInfo> conveyorInfoDict = new Dictionary<string, ConveyorInfo>()
    {
        {"ll", new ConveyorInfo(new Vector2(-.03f, .068f), new Vector2(-1,0), -180, prefabEnum.conveyorBelt, Vector2.zero) },
        {"rr", new ConveyorInfo(new Vector2(.014f, -.074f), new Vector2(1,0), 0, prefabEnum.conveyorBelt, Vector2.zero)},
        {"uu", new ConveyorInfo(new Vector2(.054f, .021f), new Vector2(0,1), 90, prefabEnum.conveyorBelt, Vector2.zero)},
        {"dd", new ConveyorInfo(new Vector2(-.078f, -.028f), new Vector2(0,-1), -90, prefabEnum.conveyorBelt, Vector2.zero)},

        {"ur", new ConveyorInfo(new Vector2(-.125f, .1232f), new Vector2(0,1), -270, prefabEnum.converyorTurn, new Vector2(1,0))},
        {"rd", new ConveyorInfo(new Vector2(.112f, .107f), new Vector2(1,0).normalized, 0, prefabEnum.converyorTurn, new Vector2(0,-1))},
        {"dl", new ConveyorInfo(new Vector2(.11f, -.128f), new Vector2(0,-1).normalized, -90, prefabEnum.converyorTurn, new Vector2(-1,0))},
        {"lu", new ConveyorInfo(new Vector2(-.134f, -.115f), new Vector2(-1,0).normalized, -180, prefabEnum.converyorTurn, new Vector2(0,1))},

        {"ld", new ConveyorInfo(new Vector2(-.18f, .12f), new Vector2(-1, 0).normalized, 0, prefabEnum.converyorTurn2, new Vector2(0,-1))},
        {"ul", new ConveyorInfo(new Vector2(.106f, .171f), new Vector2(0, 1).normalized, -90, prefabEnum.converyorTurn2, new Vector2(-1, 0))},
        {"ru", new ConveyorInfo(new Vector2(.155f, -.123f), new Vector2(1,0).normalized, -180, prefabEnum.converyorTurn2, new Vector2(0,1))},
        {"dr", new ConveyorInfo(new Vector2(-.132f, -.178f), new Vector2(0,-1).normalized, -270, prefabEnum.converyorTurn2, new Vector2(1, 0))},
        {"woodChopper", new ConveyorInfo(new Vector2(.0805f, .9293f), new Vector2(1,0), 0, prefabEnum.woodChopper, Vector2.zero)},
        {"packingMachine", new ConveyorInfo(new Vector2(1.082f,.919f), new Vector2(1,0), 0, prefabEnum.packager, Vector2.zero)},

    };

    private void InitializePart(string converyorID)
    {
        Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(worldPosition);

        if (!targetCell.cellOcupided)
        {
            gridController.currentGrid.grid[targetCell.gridIndex.x, targetCell.gridIndex.y].cellOcupided = true;
            ConveyorInfo converyorInfo = conveyorInfoDict[converyorID]; 
            gridController.currentGrid.grid[targetCell.gridIndex.x, targetCell.gridIndex.y].SetVelocity(converyorInfo.conveyorVelocity);
            Instantiate(GetPrefab(converyorInfo.prefab), targetCell.worldPos + converyorInfo.placementOffset, 
                        Quaternion.Euler(gameObject.transform.rotation.x, gameObject.transform.rotation.y, converyorInfo.rotation));
            if (converyorInfo.prefab == prefabEnum.converyorTurn || converyorInfo.prefab == prefabEnum.converyorTurn2)
            {
                gridController.currentGrid.grid[targetCell.gridIndex.x, targetCell.gridIndex.y].SetTurnVelocity(converyorInfo.conveyorVelocity, converyorInfo.finishingVelocity);
            }
        }
    }
    
    private GameObject GetPrefab(prefabEnum ID)
    {

        switch (ID)
        {
            case prefabEnum.conveyorBelt:
                return conveyorBelt;
            
            case prefabEnum.converyorTurn:
                return converyorTurn;

            case prefabEnum.converyorTurn2:
                return converyorTurn2;


            default:
                return null;

        }
    }
}
