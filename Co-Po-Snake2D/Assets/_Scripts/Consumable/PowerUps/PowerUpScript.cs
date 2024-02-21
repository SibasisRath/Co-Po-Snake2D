using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField] private InGameSprites powerUpSprite;
    [SerializeField] private float effectiveTime;

    public InGameSprites PowerUpSprite { get => powerUpSprite; }
    public float EffectiveTime { get => effectiveTime; }
}
