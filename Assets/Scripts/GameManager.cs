using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int difficulty;
    public float sfxVolume;
    public float bgmVolume;
    public float highScore;

    private void Awake()
    {

        int numGameObject = FindObjectsOfType<GameManager>().Length;
        if (numGameObject != 1)
        {
            Destroy(gameObject);
        }

        // Fait en sorte que le GameManager soit persistent au travers les scènes
        DontDestroyOnLoad(gameObject);

    }
}
