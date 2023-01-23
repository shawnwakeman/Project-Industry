using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrenceBehavor : MonoBehaviour
{
    public GameObject outputObject;
    [SerializeField] float outputRate;
    public int stock;
    public bool truckPresent;
    Vector2Int targetGridIndex;

    [SerializeField] GridController gridController;

    List<Collider2D> overlappingColliders = new List<Collider2D>();

    // Update is called once per frame
    void Start()
    {
        gridController = GameObject.Find("Grid1").GetComponent<GridController>();
        StartCoroutine(RunEverySecond());
    }

    IEnumerator RunEverySecond()
    {
        while (true)
        {
            Cell targetCell = gridController.currentGrid.GetCellFromWorldPos(transform.position);
            
            if (stock > 0 && truckPresent && outputObject != null && targetCell.cellOcupided && overlappingColliders.Count == 0)
            {
                Instantiate(outputObject, transform.position + new Vector3(-.03f, 0, 0), transform.rotation);
                outputObject.GetComponent<movementController>().gridController = gridController;
                outputObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(1, 0));
                stock--;
            }

            yield return new WaitForSeconds(outputRate);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!overlappingColliders.Contains(collider))
        {
            if (collider.gameObject.CompareTag("item"))
            {
                overlappingColliders.Add(collider);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        overlappingColliders.Remove(collider);
  
    }

}
