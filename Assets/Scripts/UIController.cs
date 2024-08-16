using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounterText;
    [SerializeField] private TextMeshProUGUI coinCounterInPopupText;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button exitInPopupButton;
    [SerializeField] private GameLogic gameController;
    [SerializeField] private GameObject popup;
    void Start()
    {
        gameController.ChangeCoinCount += AddCountCoint;
        gameController.GameOver += ShowPopup;
        exitButton.onClick.AddListener(ApplicationQuit);
        pauseButton.onClick.AddListener(OnPauseClick);
        exitInPopupButton.onClick.AddListener(OnPauseClick);

        AddCountCoint(0);
    }

    private void AddCountCoint(int count)
    {
        coinCounterText.text = $"Coins: {count}";
        coinCounterInPopupText.text = $"Coins: {count}";
    }

    private void ShowPopup() 
    {
        popup.SetActive(true);
    }

    private void ApplicationQuit()
    {
        Application.Quit();
    }

    private void OnPauseClick()
    {
        SceneManager.LoadScene(1);
    }

}
