using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayerInputDirection : MonoBehaviour
{
    private Directions direction;
    [SerializeField] Snake snake;

    public Directions Direction { get => direction; set => direction = value; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Direction = Directions.Up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Direction = Directions.Down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Direction = Directions.Left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Direction = Directions.Right;
        }
        snake.Direction = direction;
    }
}
