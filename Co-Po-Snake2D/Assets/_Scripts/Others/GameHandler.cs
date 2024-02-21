using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    private static GameStates state;
    [SerializeField] private Snake snakeReferenceOne;
    private LevelGrid levelGrid;

    private const float powerUpLifeTime = 3; //given in the instruction

    public static GameStates State { get => state; set => state = value; }


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game started");
        State = GameStates.Start;

        levelGrid = new LevelGrid(200,200, 10);

        snakeReferenceOne.LevelGridSetUp(levelGrid);
        levelGrid.SnakeSetUp(snakeReferenceOne);

        levelGrid.SpawnFood();
        levelGrid.SpawnPowerUps();
        StartCoroutine(FoodSpawnCoroutine());
        StartCoroutine(PowerUpSpawnCoroutine());
    }

    private IEnumerator FoodSpawnCoroutine()
    {
        while (true)
        {
            // Wait for a random interval before attempting to spawn food
            float randomInterval = Random.Range(5f, 10f);
            yield return new WaitForSeconds(randomInterval);

            // Check if the game is not paused before spawning food
            if (State != GameStates.Pause && State != GameStates.GameOver)
            {
                levelGrid.SpawnFood();
            }
        }
    }

    private IEnumerator PowerUpSpawnCoroutine()
    {
        while (true)
        {
            // Wait for a random interval before attempting to spawn food
            float randomInterval = Random.Range(7f, 10f);
            yield return new WaitForSeconds(randomInterval);

            // Check if the game is not paused before spawning food
            if (State != GameStates.Pause && State != GameStates.GameOver)
            {
                levelGrid.SpawnPowerUps();
            }
        }
    }

    private void Update()
    {

        if (State != GameStates.Pause & Input.GetKeyDown(KeyCode.P))//visual instruction is given in the game.
        {
            State = GameStates.Pause;
            snakeReferenceOne.SnakeState = SnakeStates.Stoped;
        }
        else if (State == GameStates.Resume)
        {
            snakeReferenceOne.SnakeState = SnakeStates.Alive;
        }

        levelGrid.DestroyFood();

    }
}
