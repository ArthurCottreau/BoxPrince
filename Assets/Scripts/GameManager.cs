using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public byte difficulty;
    public float sfxVolume;
    public float bgmVolume;
    public Slider sfx;
    public Slider bgm;
    public TMP_Text diff;
    public void sfxOption()
    {
        sfxVolume = sfx.value;
    }
    public void bgmOption()
    {
        bgmVolume = bgm.value;
    }
    //gère a difficulté ; cycle au travers Facile, Normale, Difficile
    public void difficultyOption()
    {
        if (difficulty == 2)
        {
            difficulty = 0;
            diff.SetText("Difficulté : Facile");
        }
        else if (difficulty == 0)
        {
            difficulty = 1;
            diff.SetText("Difficulté : Normale");
        }
        else if (difficulty == 1)
        {
            difficulty = 2;
            diff.SetText("Difficulté : Difficile");
        }
    }
    private void Awake()
    {
        // Fait en sorte que le GameManager soit persistent au travers les scènes
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
