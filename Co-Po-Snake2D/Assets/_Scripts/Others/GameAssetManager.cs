using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssetManager : MonoBehaviour
{
   public static GameAssetManager instance;

    private void Awake()
    {
        instance = this;
    }

    [Header("Foods")]
    [SerializeField] private GameObject massGainer1;
    [SerializeField] private GameObject massGainer2;
    [SerializeField] private GameObject massBurner1;
    [SerializeField] private GameObject massBurner2;

    [Space]
    [Header("PowerUps")]
    [SerializeField] private GameObject speedBoostPowerUp;
    [SerializeField] private GameObject scoreBoostPowerUp;
    [SerializeField] private GameObject shildPowerUp;

    [Space]
    [Header("SnakeBodyParts")]
    [SerializeField] private GameObject snakeHead1;
    [SerializeField] private GameObject snakeBodyPart1;
    [SerializeField] private GameObject snakeHead2;
    [SerializeField] private GameObject snakeBodyPart2;

    public GameObject GetAssetGameObject(InGameSprites spriteName)
    {
        GameObject resultObject;
        switch (spriteName)
        {
            case InGameSprites.MassGainer1:
                resultObject = Instantiate(massGainer1);
                break;
            case InGameSprites.MassGainer2:
                resultObject = Instantiate(massGainer2);
                break;
            case InGameSprites.MassBurner1:
                resultObject = Instantiate(massBurner1);
                break;
            case InGameSprites.MassBurner2:
                resultObject = Instantiate(massBurner2);
                break;
            case InGameSprites.ScoreBoostPowerUp:
                resultObject = scoreBoostPowerUp;
                break;
            case InGameSprites.ShieldPowerUp:
                resultObject = shildPowerUp;
                break;
            case InGameSprites.SpeedBoostPowerUp:
                resultObject = speedBoostPowerUp;
                break;
            case InGameSprites.SnakeBodySegment:
                resultObject = Instantiate(snakeBodyPart1);
                break;
            default:
                resultObject = null;
                Debug.Log("There are no such sprite in game.");
                break;
        }

        
        return resultObject;
    }

    public GameObject GetFoodObject(int snakeSize)
    {
        GameObject foodObject;
        if (snakeSize < 5)
        {
            int a = Random.Range(0, 2);
            foodObject = (a == 0) ? GetAssetGameObject(InGameSprites.MassGainer1) : GetAssetGameObject(InGameSprites.MassGainer2);
        }
        else
        {
            int a = Random.Range(0, 4);
            switch (a)
            {
                case 0:
                    foodObject = GetAssetGameObject(InGameSprites.MassBurner1);
                    break;
                case 1:
                    foodObject = GetAssetGameObject(InGameSprites.MassBurner1);
                    break;
                case 2:
                    foodObject = GetAssetGameObject(InGameSprites.MassBurner1);
                    break;
                case 3:
                    foodObject = GetAssetGameObject(InGameSprites.MassBurner1);
                    break;
                default:
                    foodObject = null;
                    Debug.Log("Food error.");
                    break;
            }
            
        }
        foodObject.transform.SetParent(gameObject.transform);
        return foodObject;
    }

}
