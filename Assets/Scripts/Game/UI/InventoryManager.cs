using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{                                                           //Déclarations pour la barre d'inventaire
    public int maxTime;                                         //durée de la barre d'inventaire
    public float speedMultiplier;                               //multiplicateur quand main vide
    public Image fill;                                          //référence à l'image de chargement

    [SerializeField] private Image activeSlot;
    [SerializeField] private Image invSlot1;
    [SerializeField] private Image invSlot2;
    [SerializeField] private Image invSlot3;

    private float currentTime;
    private float timeSpeed = 1;

                                                            //Déclarations pour le système d'inventaire
    public List<PlatformScript> platformsList;                  // array pioche des différentes plateformes
    public List<PlatformScript> inventory;                      // array inventaire, 0 étant la main du joueur, limité à 4 slots plus tard
    private PlatformScript temp;                                // variable temp pour switch

    public void NewBlock()
    {
        int rnd = Random.Range(0, platformsList.Count);         // tire un nombre aléatoire entre 0 et la taille de la liste des plateformes
        inventory.Add(platformsList[rnd]);                      // ajoute à l'inventaire la plateforme correspondante
    }
    
    // pour une raison ou une autre, les bouttons refusent d'appeler des fonctions demandants une entrée.
    // Je voulais faire qu'une seule fonction InvSwap à la base mais bon...
    public void InvSwap1(/* byte a*/) // c'était l'idée
    {
        if (inventory.Count >= 2)
        {
            temp = inventory[1];
            inventory[1] = inventory[0];
            inventory[0] = temp;
        }
        else Debug.LogWarning("Attention : Le slot d\'inventaire " + 1 + " est vide.");
    }
    public void InvSwap2()
    {
        if (inventory.Count >= 3)
        {
            temp = inventory[2];
            inventory[2] = inventory[0];
            inventory[0] = temp;
        }
        else Debug.LogWarning("Attention : Le slot d\'inventaire " + 2 + " est vide.");
    }
    public void InvSwap3()
    {
        if (inventory.Count >= 4)
        {
            temp = inventory[3];
            inventory[3] = inventory[0];
            inventory[0] = temp;
        }
        else Debug.LogWarning("Attention : Le slot d\'inventaire " + 3 + " est vide.");
    }
    private void multiply_speed()
    {
        fill.color = Color.gray;
        timeSpeed = speedMultiplier;
    }
    private void BarUpdate()
    {
        if (currentTime >= maxTime) // check si barre inventaire est remplie
        {
            if (inventory.Count < 4) // l'inventaire ne peut pas dépasser 4
            {
                NewBlock();
                timeSpeed = 1;
                fill.color = Color.black;
                currentTime = 0;
            }
        }
        else // remplissage barre si pas remplie
        {
            currentTime += (1 * Time.deltaTime * timeSpeed);
        }
        fill.fillAmount = currentTime / maxTime; // display barre
    }
    private void InvDisplay()
    {
        int size = inventory.Count;
        if (size > 0) activeSlot.sprite = inventory[0].icon;
        else activeSlot.sprite = null;
        if (size > 1) invSlot1.sprite = inventory[1].icon;
        else invSlot1.sprite = null;
        if (size > 2) invSlot2.sprite = inventory[2].icon;
        else invSlot2.sprite = null;
        if (size > 3) invSlot3.sprite = inventory[3].icon;
        else invSlot3.sprite = null;

    }
    public PlatformScript GetInvSlot(byte a)
    {
        return inventory[a];
    }
    public void ClearActiveSlot()
    {
        inventory.RemoveAt(0);
    }
    private void Start()
    {
        currentTime = 0;
        fill.fillAmount = 0;
        NewBlock();
    }
    private void Update()
    {
        BarUpdate();
        InvDisplay();
        if (inventory.Count == 0) multiply_speed();
    }
}
