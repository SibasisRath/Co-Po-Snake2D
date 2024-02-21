using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PowerUp")]
public class PowerUpScriptableObject : ScriptableObject
{
    [SerializeField] private InGameSprites powerUp;

    public InGameSprites PowerUp { get => powerUp; }
}
