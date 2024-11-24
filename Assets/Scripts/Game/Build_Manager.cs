using System.Collections.Generic;
using UnityEngine;

public class Build_Manager : MonoBehaviour
{
    [SerializeField] private Transform level_layer;
    [SerializeField] private GameObject select_obj;
    [SerializeField] private Color col_build;
    [SerializeField] private Color col_unbuild;

    private SpriteRenderer sprite_rend;
    private UIManager ui_manag;
    private InventoryManager inv_manag;
    private List<GameObject> trig_list = new List<GameObject>();
    private bool can_build = true;

    private void Start()
    {
        sprite_rend = gameObject.GetComponent<SpriteRenderer>();
        inv_manag = gameObject.GetComponent<InventoryManager>();
        ui_manag = gameObject.GetComponent<UIManager>();
    }

    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = pos;
        if (can_build && Input.GetMouseButtonDown(0))
        {
            Instantiate(select_obj, pos, Quaternion.identity, level_layer);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        trig_list.Add(collision.gameObject);

        can_build = false;
        sprite_rend.color = col_unbuild;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trig_list.Remove(collision.gameObject);

        if (trig_list.Count == 0)
        {
            can_build = true;
            sprite_rend.color = col_build;
        }
    }
}