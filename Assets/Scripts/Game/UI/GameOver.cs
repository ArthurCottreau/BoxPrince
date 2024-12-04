using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class GameOver : MonoBehaviour
{
    [SerializeField] private UIManager manager;
    [SerializeField] private GameObject goui; // goui moment                                            (Game Over User Interface)
    [SerializeField] private TMP_Text display_score;
    [SerializeField] private TMP_Text display_height;
    [SerializeField] private ScoreManager scoreManager;

    private float finalScore;
    private float finalHeight;

    public void Death() // public pour être appelée par des objets externes
    {
        Debug.Log("You are dead! Not big suprise!");

        // Récupère le score puis l'affiche sur l'UI GameOver
        finalScore = Mathf.Round(manager.GetScore());
        finalHeight = Mathf.Round(manager.GetHeight() * 100f) / 100f;
        display_score.text = ("Score : " + finalScore);
        display_height.text = ("Hauteur : " + finalHeight + "m");
        goui.SetActive(true);

        // Sauvegarde le Score
        scoreManager.newScore((int)finalScore, finalHeight);
    }
    public float GetFinalScore()
    {
        return finalScore;
    }
    public float GetFinalHeight()
    {
        if (finalHeight == 0)
        {
            Debug.LogWarning("Attention, la hauteur récupérée est de 0 : est-ce du à un appel de la fonction avant un Game Over ?");
        }
        return finalHeight;
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
