using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemController : MonoBehaviour
{
    public PlatformScript Item;
    private Sprite ItemIcon;

    private float decaytime;
    private float decayMultiplier;

    private void Start()
    {
        ItemIcon = Item.icon;
        decaytime = Item.decayTime;
        decayMultiplier = Item.decayMultiplier;
    }

    public void OnCollision()
    {
        decaytime -= Item.decayCollision;
    }

    private void Update()
    {
        decaytime -= Time.deltaTime * decayMultiplier;

        Debug.Log(decaytime);

        if (decaytime < (Item.decayTime * 0.8f))
        {
            Debug.Log("80 %");
        }

        if (decaytime < 0)
        {
            Destroy(gameObject);
        }
    }
}
