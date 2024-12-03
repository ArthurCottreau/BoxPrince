using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float speed;
    [SerializeField] private GameObject wallLeft;
    [SerializeField] private GameObject wallRight;

    private bool willFollow = true;

    private void FixedUpdate()
    {
        if (willFollow)
        {
            if (target.transform.position.y > gameObject.transform.position.y)
            {
                Vector3 newpos = new Vector3(0, target.transform.position.y, -10);
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, newpos, speed);

                wallLeft.transform.position = new Vector3(-14.75f, newpos.y, 0);
                wallRight.transform.position = new Vector3(14.75f, newpos.y, 0);
            }

            if (target.transform.position.y < gameObject.transform.position.y - 10.5f)
            {
                Death();
            }
        }
    }

    public void Death() //la fonction fait pas grand chose pour l'instant.
    {
        Debug.Log("You are dead! Not big suprise!");
        target.GetComponent<Player_Controller>().isDead = true;
        willFollow = false;
    }
}
