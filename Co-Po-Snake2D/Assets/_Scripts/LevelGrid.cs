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

    public void SetUp(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(GenerateRandomNumber(width), GenerateRandomNumber(height));
        } while (snake.GetSnakeGritPosition() == foodGridPosition);
        

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssetManager.instance.GetSprite(InGameSprites.MassGainer1);
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    private int GenerateRandomNumber(int max)
    {
        // Here to adjust min and max and generate a random number which is divisible by unitGrid I am rounding up min and rounding down max respectively to the nearest multiple of unitGrid.
        //because min value is 0
        int adjustedMax = Mathf.FloorToInt((float)max / unitGrid);

        return (int)(Random.Range(0,adjustedMax+1))*unitGrid;
    }

    public void SnakeMoved(Vector2Int snakePos)
    {
        if (snakePos == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            Debug.Log("Snake ate food.");
        }
    }

}
