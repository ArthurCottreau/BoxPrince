using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.GraphicsBuffer;

public class GameOver : MonoBehaviour
{
    [SerializeField] private UIManager manager;
    [SerializeField] private GameObject goui; // goui moment                                            (Game Over User Interface)
    [SerializeField] private TMP_Text display_score;
    [SerializeField] private TMP_Text display_height;
    private ScoreManager scoreManager;

    private int finalScore;
    private float finalHeight;

    // partie audio
    private AudioSource sfx;
    [SerializeField] private AudioClip audioLose;

    private void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();
        sfx = gameObject.GetComponent<AudioSource>();
        sfx.volume = GameObject.Find("GameManager").GetComponent<GameManager>().sfxVolume / GameObject.Find("GameManager").GetComponent<GameManager>().sfxOffset;
    }

    public void Death() // public pour �tre appel�e par des objets externes
    {
        // R�cup�re le score puis l'affiche sur l'UI GameOver
        finalScore = Mathf.RoundToInt(manager.GetScore());
        finalHeight = manager.GetHeight();
        display_score.text = "Score : " + finalScore;
        display_height.text = "Hauteur : " + finalHeight.ToString("0.00") + "m";
        goui.SetActive(true);
        sfx.clip = audioLose;
        sfx.Play();
        GameObject.Find("GameManager").GetComponent<AudioSource>().volume /= 3;
        // Sauvegarde le Score
        scoreManager.newScore(finalScore, finalHeight);

        // Met � jour le highscore dans le GameManager
        manager.update_hscore(finalScore);
    }
    public int GetFinalScore()
    {
        return finalScore;
    }
    public float GetFinalHeight()
    {
        if (finalHeight == 0)
        {
            Debug.LogWarning("Attention, la hauteur r�cup�r�e est de 0 : est-ce du � un appel de la fonction avant un Game Over ?");
        }
        return finalHeight;
    }

    public void nextScene(int scene)
    {
        if (scene == 1) GameObject.Find("GameManager").GetComponent<AudioSource>().volume *= 3;
        SceneManager.LoadScene(scene);
    }
}
