using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;

    private void FixedUpdate()
    {
        if (target.position.y > gameObject.transform.position.y)
        {
            Vector3 newpos = new Vector3(0, target.position.y, -10);
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newpos, speed);
        }
    }
}
