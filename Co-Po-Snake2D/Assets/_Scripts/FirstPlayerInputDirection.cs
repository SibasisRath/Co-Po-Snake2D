using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlayerInputDirection : MonoBehaviour
{
    private Directions direction;
    [SerializeField] private Snake snake;
    [SerializeField] private Timer timer;

    public Directions Direction { get => direction; set => direction = value; }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Direction = Directions.Up;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Direction = Directions.Left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Direction = Directions.Down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Direction = Directions.Right;
        }
        ChangeDirection(Direction);
    }

    private void ChangeDirection(Directions d)
    {
        //this checks to change the direction twice at a single place
        if (timer.CanPerform)
        {
            snake.Direction = d;
        }
    }
}
