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

   // public Sprite snakeHead;
    [SerializeField] private Sprite massGainer1;
    [SerializeField] private Sprite massGainer2;
    [SerializeField] private Sprite massLosser1;
    [SerializeField] private Sprite massLosser2;
    [SerializeField] private Sprite speedBoostPowerUp;
    [SerializeField] private Sprite scoreBoostPowerUp;
    [SerializeField] private Sprite shildPowerUp;
    [SerializeField] private Sprite snakeBodyPart;

    public Sprite GetSprite(InGameSprites spriteName)
    {
        Sprite resultSprite;
        switch (spriteName)
        {
            case InGameSprites.MassGainer1:
                resultSprite = massGainer1;
                break;
            case InGameSprites.MassGainer2:
                resultSprite = massGainer2;
                break;
            case InGameSprites.MassLosser1:
                resultSprite = massLosser1;
                break;
            case InGameSprites.MassLosser2:
                resultSprite = massLosser2;
                break;
            case InGameSprites.ScoreBoostPowerUp:
                resultSprite = scoreBoostPowerUp;
                break;
            case InGameSprites.ShieldPowerUp:
                resultSprite = shildPowerUp;
                break;
            case InGameSprites.SpeedBoostPowerUp:
                resultSprite = speedBoostPowerUp;
                break;
            case InGameSprites.SnakeBodySegment:
                resultSprite = snakeBodyPart;
                break;
            default:
                resultSprite = null;
                Debug.Log("There are no such sprite in game.");
                break;
        }
        return resultSprite;
    }

}
