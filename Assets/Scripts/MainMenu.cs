using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private Button startGameButton;
    void Start()
    {
        startGameButton.onClick.AddListener(OnStartClick);
    }

    
    private void OnStartClick()
    {
        SceneManager.LoadScene(2);
    }
}
