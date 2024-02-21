using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    //[SerializeField] private GameHandler gameHandler;
    [Space]
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private Button mainButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button resumeButton;
    
    private void Start()
    {
        //gameHandler.State = GameStates.Start;
        panel.SetActive(false);
        message.gameObject.SetActive(false);
        SetUpButton(mainButton, BackToMainButtonClicked);
        SetUpButton(restartButton, RestartButtonClicked);
        SetUpButton(resumeButton, ResumeButtonClicked);
        mainButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GameHandler.State == GameStates.Pause)
        {
            OnPause();
        }

        if (GameHandler.State == GameStates.GameOver)
        {
            OnGameOver();
        }

    }

    private void SetUpButton(Button button, UnityAction unityAction)
    {
        if (button != null)
        {
            button.onClick.AddListener(() => {
                //SoundManager.Instance.Play(Sounds.ButtonClick);
                unityAction?.Invoke();
            });
        }
        else
        {
            Debug.Log($"{button} is null.");
        }
    }

    private void RestartButtonClicked()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void BackToMainButtonClicked()
    {
        //SceneManager.LoadScene(0);
    }


    private void ResumeButtonClicked()
    {
        GameHandler.State = GameStates.Resume;
        panel.SetActive(false);
        message.gameObject.SetActive(false);
        mainButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
    }

    private void OnPause()
    {
        GameHandler.State = GameStates.Pause;
        panel.SetActive(true);
        message.gameObject.SetActive(true);
        message.text = "Pause";
        mainButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
    }

    private void OnGameOver()
    {
        GameHandler.State = GameStates.End;
        panel.SetActive(true);
        message.gameObject.SetActive(true);
        message.text = "GameOver";
        mainButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
