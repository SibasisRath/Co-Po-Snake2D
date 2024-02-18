using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    private static GameStates state;
    [SerializeField] private Snake snakeReferenceOne;
    private LevelGrid levelGrid;

    public static GameStates State { get => state; set => state = value; }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game started");
        State = GameStates.Start;

        levelGrid = new LevelGrid(200,200, 10);

        snakeReferenceOne.LevelGridSetUp(levelGrid);
        levelGrid.SnakeSetUp(snakeReferenceOne);
    }

}
