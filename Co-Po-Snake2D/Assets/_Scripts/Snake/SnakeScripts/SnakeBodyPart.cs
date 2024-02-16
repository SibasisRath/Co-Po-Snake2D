using UnityEngine;

public class SnakeBodyPart
{
    private Transform transform;
    private Vector2Int gridPosition;

   public SnakeBodyPart(int bodyIndex)
    {
        GameObject snakeBodyGameObject = new GameObject("SnakeBody", typeof(SpriteRenderer));
        snakeBodyGameObject.GetComponent<SpriteRenderer>().sprite = GameAssetManager.instance.GetSprite(InGameSprites.SnakeBodySegment);
        snakeBodyGameObject.GetComponent<SpriteRenderer>().sortingOrder = -bodyIndex;
        transform = snakeBodyGameObject.transform;
    }

    public void SetGridPosition(Vector2Int gridPosition)
    {
        this.gridPosition = gridPosition;
        transform.position = new Vector3(this.gridPosition.x, this.gridPosition.y);
    }
}
