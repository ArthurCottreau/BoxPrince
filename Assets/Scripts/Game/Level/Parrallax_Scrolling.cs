using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Parrallax_Scrolling : MonoBehaviour
{
    [SerializeField] private float scroll_speed;

    private Transform cam_pos;
    private float start_pos;
    private float height;

    void Start()
    {
        cam_pos = Camera.main.transform;
        start_pos = transform.position.y;
        height = GetComponent<SpriteRenderer>().bounds.size.y / 2;

        move_layer();
    }

    void FixedUpdate()
    {
        move_layer();
        loop_layer();
    }

    void move_layer()
    {
        float new_pos = cam_pos.position.y * scroll_speed;
        transform.position = new Vector3(0, start_pos + new_pos, 0);
    }

    void loop_layer()
    {
        float threshold = (cam_pos.position.y * (1 - scroll_speed));
        if (threshold > start_pos + (height / 2))
        {
            start_pos += height;
        }
    }
}
