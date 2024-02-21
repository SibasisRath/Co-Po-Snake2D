using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LevelGrid
{
    private Vector2Int consumablesGridPosition;
    private int width;
    private int height;
    private int unitGrid;

    private GameObject food;
    private GameObject powerUps;
    private List<GameObject> foodGameObjects = new List<GameObject>();
    private List<GameObject> powerUpsGameObjects = new List<GameObject>();

    private Snake snake;

    public LevelGrid(int width, int height, int unitGrid)
    {
        this.width = width;
        this.height = height;
        this.unitGrid = unitGrid;   
    }

    public void SnakeSetUp(Snake snake)
    {
        this.snake = snake;
    }


    private int GenerateRandomNumber(int max)
    {
        // Here to adjust min and max and generate a random number which is divisible by unitGrid I am rounding up min and rounding down max respectively to the nearest multiple of unitGrid.
        //because min value is 0
        int adjustedMax = Mathf.FloorToInt((float)max / unitGrid);

        return (int)(Random.Range(0, adjustedMax + 1)) * unitGrid;
    }

    private Vector2Int SpawnlocationFinder()
    {
        do
        {
            consumablesGridPosition = new Vector2Int(GenerateRandomNumber(width), GenerateRandomNumber(height));
        } while (snake.GetSnakePositions().IndexOf(consumablesGridPosition) != -1 && foodGameObjects.FindIndex(obj => obj.transform.position == new Vector3(consumablesGridPosition.x, consumablesGridPosition.y, 0)) != -1 && powerUpsGameObjects.FindIndex(obj => obj.transform.position == new Vector3(consumablesGridPosition.x, consumablesGridPosition.y, 0)) != -1);

        return consumablesGridPosition;
    }

    public void SpawnFood()
    {
       
        Vector2Int foodGridPosition = SpawnlocationFinder();

        food = GameAssetManager.instance.GetFoodObject(snake.SnakeBodySize);
        food.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
        foodGameObjects.Add(food);
    }

    public void SpawnPowerUps()
    {
        Vector2Int powerUpGridPosition = SpawnlocationFinder();
        powerUps = GameAssetManager.instance.GetPowerUp();
        powerUps.transform.position = new Vector3(powerUpGridPosition.x, powerUpGridPosition.y);
        powerUpsGameObjects.Add(powerUps);
    }

    public void DestroyFood()
    {
        // Iterate through foodGameObjects
        for (int i = 0; i < foodGameObjects.Count; i++)
        {
            
            if (foodGameObjects[i] != null)
            {
                ConsumableStates consumableState = foodGameObjects[i].GetComponent<FoodScript>().ConsumableState;
                if (consumableState == ConsumableStates.Eaten || consumableState == ConsumableStates.Rotten)
                {
                    Object.Destroy(foodGameObjects[i]);
                }
            }
            
        }
        // Remove destroyed GameObjects from foodGameObjects list
        foodGameObjects.RemoveAll(obj => obj == null);
    }

    public bool CheckSnakeAteFood(Vector2Int snakePos, out FoodScript foodScript)
    {
        bool res = false;
        FoodScript foodScript1 = null;
        for (int i = 0; i < foodGameObjects.Count; i++)
        {
            if (snakePos == new Vector2Int((int)foodGameObjects[i].transform.position.x, (int)foodGameObjects[i].transform.position.y))
            {
                foodScript1 = foodGameObjects[i].GetComponent<FoodScript>();
                foodScript1.ConsumableState = ConsumableStates.Eaten;
                res = true;
                break;
            }
            res = false;
        }
        foodScript = foodScript1;
        return res;
    }

    //in instruction there is no mention of destroying power ups. 
    public bool CheckSnakeAtePowerUp(Vector2Int snakePos, out GameObject powerUp)
    {
        bool res = false;
        GameObject resultPowerUp = null;

        for (int i = 0; i < powerUpsGameObjects.Count; i++)
        {
            if (powerUpsGameObjects[i] != null && snakePos == new Vector2Int((int)powerUpsGameObjects[i].transform.position.x, (int)powerUpsGameObjects[i].transform.position.y))
            {
                resultPowerUp = powerUpsGameObjects[i];
                res = true;
                break;
            }
            res = false;
        }
        powerUp = resultPowerUp;

        Object.Destroy(resultPowerUp);
        powerUpsGameObjects.RemoveAll(obj => obj == null);
        return res;
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if (gridPosition.x<0)
        {
            gridPosition.x = width;
        }

        if (gridPosition.x > width)
        {
            gridPosition.x = 0;
        }

        if (gridPosition.y < 0)
        {
            gridPosition.y = height;
        }

        if (gridPosition.y > height)
        {
            gridPosition.y = 0;
        }

        return gridPosition;
    }

}
