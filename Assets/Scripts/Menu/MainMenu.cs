using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject leaderboard;
    [SerializeField] private GameObject options;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private string sceneName;
    public void Awake()
    {
        mainMenu.SetActive(true);
        leaderboard.SetActive(false);
        options.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LeaderBoardOpen()
    {
        leaderboard.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void LeaderBoardClose()
    {
        leaderboard.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void OptionsOpen()
    {
        options.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void OptionsClose()
    {
        options.SetActive(false);
        mainMenu.SetActive(true);
    }
}
