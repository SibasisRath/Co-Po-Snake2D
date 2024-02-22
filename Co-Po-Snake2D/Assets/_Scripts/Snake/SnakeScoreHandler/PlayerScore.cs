using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    private int score;
    [SerializeField] private TextMeshProUGUI playerScore;

    public int Score { get => score; }

    private void Start()
    {
        score = 0;
        //UpdateUI();
    }

    public void UpdateScore(int score, PlayerEnum player)
    {
        this.score += score;
        UpdateUI(player);
        Debug.Log(Score);
    }

    private void UpdateUI(PlayerEnum player)
    {
        if (player == PlayerEnum.Player1)
        {
            playerScore.text = "Player Score\n" + score;
        }
        
    }

}
