using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    private ConsumableStates consumableState;
    [SerializeField] private int score;
    [SerializeField] private int bodyGrow;
    [SerializeField] private float foodLifeTime;

    public int Score { get => score; }
    public int BodyGrow { get => bodyGrow;}
    public ConsumableStates ConsumableState { get => consumableState; set => consumableState = value; }

    private void Start()
    {
        consumableState = ConsumableStates.Spawned;
        foodLifeTime = 7f;
        StartCoroutine(FoodLifeTime());
    }

    private IEnumerator FoodLifeTime()
    {
        yield return new WaitForSeconds(foodLifeTime);
        consumableState = ConsumableStates.Rotten;
    }
}
