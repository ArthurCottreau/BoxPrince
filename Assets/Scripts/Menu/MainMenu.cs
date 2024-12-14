using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    // partie audio
    [SerializeField] private AudioSource uisfx;
    [SerializeField] private AudioClip UI_Click;
    [SerializeField] private AudioClip UI_sfxtest;

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
        uisfx.volume = gManager.sfxVolume / 100 / gManager.sfxOffset;
    }
    public void StartGame()
    {
        uisfx.clip = UI_Click;
        uisfx.Play();

        // fix dégueulasse : le highscore affichait 0 ingame si le leaderboard était jamais ouvert
        GameManager gameManager = gManager.GetComponent<GameManager>();
        ScoreManager scoreManager = gManager.GetComponent<ScoreManager>();
        ScoreData data = scoreManager.getScores();
        data.scoreList = data.scoreList.OrderByDescending(go => go.scoreJoueur).ToList<ElementScore>();
        if (data.scoreList.Count > 0) gameManager.highScore = data.scoreList[0].scoreJoueur;

        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        uisfx.clip = UI_Click;
        uisfx.Play();
        Application.Quit();
    }
    public void LeaderBoardOpen()
    {
        uisfx.clip = UI_Click;
        uisfx.Play();
        leaderboard.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void LeaderBoardClose()
    {
        uisfx.clip = UI_Click;
        uisfx.Play();
        leaderboard.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void OptionsOpen()
    {
        uisfx.clip = UI_Click;
        uisfx.Play();
        options.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void OptionsClose()
    {
        uisfx.clip = UI_Click;
        uisfx.Play();
        options.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void sfxOption()
    {
        if (!uisfx.isPlaying)
        {
            uisfx.clip = UI_sfxtest;
            uisfx.Play();
        }
        PlayerPrefs.SetFloat("sfx", gManager.sfxVolume);
        uisfx.volume = gManager.sfxVolume / 100;
        gManager.sfxVolume = sfx.value;
    }
    public void bgmOption()
    {
        gManager.bgmVolume = bgm.value;
        PlayerPrefs.SetFloat("bgm", gManager.bgmVolume);
        gManager.BgmVolume();
    }

    //gère la difficulté ; cycle au travers Facile, Normale, Difficile
    public void difficultyOption()
    {
        uisfx.clip = UI_Click;
        uisfx.Play();
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
