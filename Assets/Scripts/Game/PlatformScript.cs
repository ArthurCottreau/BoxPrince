using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Platform", menuName = "Platform/Create New Platform")]
public class PlatformScript : ScriptableObject
{
    public int id;
    public Sprite icon;
    public GameObject prefab;

    //public float decayTime; //Temps d'errosion du block
    //public float decayCollision; //Temps soustrait � l'errosion du block quand entre en contact avec joueur
    //public float decayMultiplier; //Multiplicateur � la vitesse d'errosion quand block est en contact avec joueur
}
