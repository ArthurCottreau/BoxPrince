using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public List<ElementScore> scoreList = new List<ElementScore>();
}

[System.Serializable]
public class ElementScore
{
    public int scoreJoueur;
    public float hauteurJoueur;

    public ElementScore(int score, float hauteur)
    {
        scoreJoueur = score;
        hauteurJoueur = hauteur;
    }
}
