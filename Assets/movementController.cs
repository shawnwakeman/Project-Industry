using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    // Start is called before the first frame update

    public GridController gridController;
    [SerializeField] Rigidbody2D item;
    [SerializeField] float speed;
    Cell cellBelow;
    Cell oldCell;
    [SerializeField] Sprite cutWoodSprite;
    [SerializeField] Sprite cardboardBoxSprite;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] float rotationSpeed;

    private float currentSecond = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        try
        {
            cellBelow = gridController.currentGrid.GetCellFromWorldPos(item.position);
            
        }
        catch (System.Exception)
        {
            Destroy(transform.gameObject);
        }

        if (cellBelow.turnPeice)
        {
            
            float t = currentSecond / 1;
            item.velocity = Vector2.Lerp(cellBelow.conveyorVelocity, cellBelow.endingVelocity, t);
            currentSecond += speed/100;

        }
        else
        {
            item.velocity = cellBelow.conveyorVelocity;

        }

        if(oldCell != cellBelow)
        {
            currentSecond = 0;
            Debug.Log(item.velocity);

        }
        else
        {
            Quaternion angle = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0,
                                            AngleBetweenVector2(item.position, item.position + item.velocity)), (speed * 10) * Time.fixedDeltaTime);
            item.MoveRotation(angle);

            

        }

        oldCell = cellBelow;

    }

    public float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
    {
        Vector2 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y)? -1.0f : 1.0f;
        return (Vector2.Angle(Vector2.right, diference) * sign);
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("woodChopper"))
        {
            spriteRenderer.sprite = cutWoodSprite;
        }
        else if (other.gameObject.CompareTag("packingMachine"))
        {
            spriteRenderer.sprite = cardboardBoxSprite;
            
        }


    }
}
