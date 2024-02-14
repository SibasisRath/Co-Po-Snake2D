using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private Vector2Int gridPosition; //Snake position on grid
    [SerializeField] private int gridUnit;
    private Vector2Int gridMoveDirection;

    private Directions direction;

    [SerializeField] private Timer timer;

    public Directions Direction { get => direction; set => direction = value; }

    private void Awake()
    {
        gridMoveDirection = new Vector2Int(gridUnit, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        HandelDirection();
        HandleMovement();
        
    }


    private void HandelDirection()
    {
        if (direction == Directions.Up && gridMoveDirection.y != -gridUnit)
        {
            gridMoveDirection.y = gridUnit;
            gridMoveDirection.x = 0;
        }

        else if (direction == Directions.Down && gridMoveDirection.y != gridUnit)
        {
            gridMoveDirection.y = -gridUnit;
            gridMoveDirection.x = 0;
        }

        else if (direction == Directions.Left && gridMoveDirection.x != gridUnit)
        {
            gridMoveDirection.x = -gridUnit;
            gridMoveDirection.y = 0;
        }

        else if (direction == Directions.Right && gridMoveDirection.x != -gridUnit)
        {
            gridMoveDirection.x = gridUnit;
            gridMoveDirection.y = 0;
        }
    }

    private void HandleMovement()
    {
        if (timer.CanPerform)
        {
            timer.CanPerform = false;
            gridPosition += gridMoveDirection;
        }
        transform.position = new Vector3(gridPosition.x, gridPosition.y);
        transform.eulerAngles = new Vector3(0,0,HandleRotation(gridMoveDirection) - 90f);
    }

    private float HandleRotation(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        if (n<0)
        {
            n += 360;
        }
        return n;
    }
}
