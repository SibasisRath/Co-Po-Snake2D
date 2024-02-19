using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameModeSelectorUIManager : MonoBehaviour
{
    [Header("panel")]
    [SerializeField] private GameObject mainPanel;
    [Space]
    [Header("Buttons")]
    [SerializeField] private Button backToMainButton;
    [SerializeField] private Button singleModeButton;
    [SerializeField] private Button copoModeButton;
    [Space]
    [Header("Serialize Object")]
    [SerializeField] private GameModeManager modeManager;

    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(false);
        SetUpButton(backToMainButton, BackToMainButtonIsClicked);
        SetUpButton(singleModeButton, SingleModeButtonIsClicked);
        SetUpButton(copoModeButton, CopoModeButtonIsClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpButton(Button button, UnityAction unityAction)
    {
        if (button != null)
        {
            //Sound
            button.onClick.AddListener(() => { unityAction?.Invoke(); });
        }
        else
        {
            Debug.Log($"error: {button} is null.");
        }
    }

    private void BackToMainButtonIsClicked()
    {
        mainPanel.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void SingleModeButtonIsClicked()
    {
        modeManager.GameMode = GameModes.SinglePlayer;
    }

    private void CopoModeButtonIsClicked()
    {
        modeManager.GameMode = GameModes.CopoPlayer;
    }
}
