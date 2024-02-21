using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameModeSelector : MonoBehaviour
{
    [SerializeField] private GameModeManager modeManager;
    [SerializeField] private Button single;
    [SerializeField] private Button copo;

    private void Start()
    {
        single.onClick.AddListener(() => { modeManager.GameMode = GameModes.SinglePlayer; });
        copo.onClick.AddListener(() => { modeManager.GameMode = GameModes.CopoPlayer; });
    }
}
