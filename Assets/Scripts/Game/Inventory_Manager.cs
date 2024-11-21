using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Manager : MonoBehaviour
{
    public int maxTime;
    public float speedMultiplier;
    public Image fill;

    private float currentTime;
    private float timeSpeed = 1;
    public void NewBlock()
    {
        //Appelée quand barre pleine, servira à ajouter un nouveau Block à l'inventaire
        Debug.Log("Ding");
    }

    void Start()
    {
        currentTime = 0;
        fill.fillAmount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fill.color = Color.gray;
            timeSpeed = speedMultiplier;
        }
        if (currentTime >= maxTime)
        {
            NewBlock();
            timeSpeed = 1;
            fill.color = Color.black;
            currentTime = 0;
        }
        else
        {
            currentTime += (1 * Time.deltaTime * timeSpeed);
        }
        fill.fillAmount = currentTime / maxTime;
    }
}
