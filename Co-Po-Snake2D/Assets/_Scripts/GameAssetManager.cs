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

    public Sprite snakeHead;
}
