using UnityEngine;
public class LevelGrid
{
    private Vector2Int foodGridPosition;
    private int width;
    private int height;
    private int unitGrid;

    private GameObject foodGameObject;

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
        SpawnFood();
    }

    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(GenerateRandomNumber(width), GenerateRandomNumber(height));
        } while (snake.GetSnakePositions().IndexOf(foodGridPosition) != -1);


        //foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        //foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssetManager.instance.GetSprite(InGameSprites.MassGainer1);
        foodGameObject = GameAssetManager.instance.GetFoodObject(snake.SnakeBodySize);
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    private int GenerateRandomNumber(int max)
    {
        // Here to adjust min and max and generate a random number which is divisible by unitGrid I am rounding up min and rounding down max respectively to the nearest multiple of unitGrid.
        //because min value is 0
        int adjustedMax = Mathf.FloorToInt((float)max / unitGrid);

        return (int)(Random.Range(0,adjustedMax+1))*unitGrid;
    }

    public bool CheckSnakeAteFood(Vector2Int snakePos, out FoodScript foodScript)
    {
        if (snakePos == foodGridPosition)
        {
            foodScript = foodGameObject.GetComponent<FoodScript>();
            Debug.Log($"Snake ate food. Body Growth {foodScript.BodyGrow}, Score Added {foodScript.Score}");
            //snake.AdditionalBodySize = foodScript.BodyGrow;
            Object.Destroy(foodGameObject);
            SpawnFood();
            
            return true;
        }
        else
        {
            foodScript = null;
            return false;
        }
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
