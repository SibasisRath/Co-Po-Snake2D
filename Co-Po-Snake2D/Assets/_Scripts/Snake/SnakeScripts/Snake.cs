using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private Timer timer; // Reference to timer
    [SerializeField] private Vector2Int snakeGridPosition; //Snake position on grid
    [SerializeField] private int gridUnit; // This is the length snake will move each time
    private Vector2Int gridMoveDirection; // This will help to change direction
    private Directions direction; // this will be the all the allowed direction
    private LevelGrid levelGrid; // Reference to Grid. This is to interact with consumable
    public void SetUp(LevelGrid levelGrid){this.levelGrid = levelGrid;}

    private int snakeBodySize; 
    private List<Vector2Int> snakeMovePositionLIst; // store the positions of the snake body parts
    private List<SnakeBodyPart> snakeBodyPartsList;

    private SnakeStates snakeState;


    public Directions Direction { get => direction; set => direction = value; }

    private void Awake()
    {
        gridMoveDirection = new Vector2Int(0, gridUnit); //initial movement
        snakeBodySize = 0;
        snakeMovePositionLIst = new List<Vector2Int>();
        snakeBodyPartsList = new List<SnakeBodyPart>();
    }

    private void Start()
    {
        snakeState = SnakeStates.Alive;
    }

    // Update is called once per frame
    void Update()
    {
        switch (snakeState)
        {
            case SnakeStates.Alive:
                HandelDirection();
                HandleMovement();
                break;
            case SnakeStates.Dead:
                break;
        }
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
            snakeMovePositionLIst.Insert(0, snakeGridPosition);
            snakeGridPosition += gridMoveDirection;

            bool snakeAteFood = levelGrid.CheckSnakeAteFood(snakeGridPosition);

            if (snakeAteFood)
            {
                snakeBodySize++;
                CreateSnakeBody();
                Debug.Log(snakeBodySize);
            }
            if (snakeMovePositionLIst.Count >= snakeBodySize + 1)
            {
                snakeMovePositionLIst.RemoveAt(snakeMovePositionLIst.Count - 1);
            }   
        }
        for (int i = 0; i < snakeBodyPartsList.Count; i++)
        {
            Vector2Int snakeBodyPartGridPosition = snakeBodyPartsList[i].GetGridPosition();
            if (snakeGridPosition == snakeBodyPartGridPosition)
            {
                snakeState = SnakeStates.Dead;
                Debug.Log("Player is dead.");
            }
        }
        transform.position = new Vector3(snakeGridPosition.x, snakeGridPosition.y);
        transform.eulerAngles = new Vector3(0,0,HandleRotation(gridMoveDirection) - 90f);
        UpdateSnakeBody();
    }

    private void CreateSnakeBody()
    {
        snakeBodyPartsList.Add(new SnakeBodyPart(snakeBodyPartsList.Count));
    }

    private void UpdateSnakeBody()
    {
        for (int i = 0; i < snakeBodyPartsList.Count; i++)
        {
            snakeBodyPartsList[i].SetGridPosition(snakeMovePositionLIst[i]);
        }
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

    public Vector2Int GetSnakeGritPosition(){return snakeGridPosition;}

    public List<Vector2Int> GetSnakePositions()
    {
        List<Vector2Int> entireSnake = new List<Vector2Int>() { snakeGridPosition };
        entireSnake.AddRange(snakeMovePositionLIst);
        return entireSnake;
    }
}
