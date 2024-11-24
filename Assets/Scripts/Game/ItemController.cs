using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public PlatformScript Item;
    private Sprite ItemIcon;
    private void Start()
    {
        ItemIcon = Item.icon;
    }
}
