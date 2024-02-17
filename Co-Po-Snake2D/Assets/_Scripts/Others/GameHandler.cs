using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Snake snakeReferenceOne;
    private LevelGrid levelGrid;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game started");

       levelGrid = new LevelGrid(200,200, 10);

        snakeReferenceOne.SetUp(levelGrid);
        levelGrid.SetUp(snakeReferenceOne);
    }

}
