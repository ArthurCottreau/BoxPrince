using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject content;

    private void Start()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ScoreManager scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>();

        ScoreData data = scoreManager.getScores();

        data.scoreList = data.scoreList.OrderByDescending(go => go.scoreJoueur).ToList<ElementScore>();
        gameManager.highScore = data.scoreList[0].scoreJoueur;

        for (int i = 0; i < data.scoreList.Count; i++)
        {
            GameObject inst = Instantiate(prefab, content.transform.position, Quaternion.identity, content.transform);
            inst.transform.Find("TextScore").GetComponent<TextMeshProUGUI>().text = "Score : " + data.scoreList[i].scoreJoueur;
            inst.transform.Find("TextHeight").GetComponent<TextMeshProUGUI>().text = "Hauteur : " + data.scoreList[i].hauteurJoueur;
        }

        RectTransform newcont = content.GetComponent<RectTransform>();
        newcont.sizeDelta = new Vector2(0, data.scoreList.Count * 60 + 10);
    }
}