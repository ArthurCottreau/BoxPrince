using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject leaderboard;
    [SerializeField] private GameObject options;
    [SerializeField] private Slider sfx;
    [SerializeField] private Slider bgm;
    [SerializeField] private TMP_Text diff;
    private GameManager gManager;

    public void Awake()
    {
        mainMenu.SetActive(true);
        leaderboard.SetActive(false);
        options.SetActive(false);
        gManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gManager.difficulty = PlayerPrefs.GetInt("Diff", 1);
        diffSetText();
        sfx.value = PlayerPrefs.GetFloat("sfx", 100);
        bgm.value = PlayerPrefs.GetFloat("bgm", 100);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
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
    public void sfxOption()
    {
        gManager.sfxVolume = sfx.value;
        PlayerPrefs.SetFloat("sfx", gManager.sfxVolume);
    }
    public void bgmOption()
    {
        gManager.bgmVolume = bgm.value;
        PlayerPrefs.SetFloat("bgm", gManager.bgmVolume);
    }

    //gère la difficulté ; cycle au travers Facile, Normale, Difficile
    public void difficultyOption()
    {
        gManager.difficulty += 1;
        if (gManager.difficulty > 2)
        {
            gManager.difficulty = 0;
        }
        diffSetText();
        PlayerPrefs.SetInt("Diff", gManager.difficulty);
    }
    public void diffSetText()
    {
        switch (gManager.difficulty)
        {
            case 0:
                diff.SetText("Difficulté : Facile");
                break;
            case 1:
                diff.SetText("Difficulté : Normale");
                break;
            case 2:
                diff.SetText("Difficulté : Difficile");
                break;
            default:
                diff.SetText("Difficulté : Euh");
                break;
        }
    }
}
