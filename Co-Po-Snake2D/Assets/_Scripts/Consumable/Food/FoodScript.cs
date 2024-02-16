using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private int bodyGrow;

    public int Score { get => score; }
    public int BodyGrow { get => bodyGrow;}
}
