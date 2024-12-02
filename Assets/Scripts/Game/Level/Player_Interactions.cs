using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interactions : MonoBehaviour
{
    [SerializeField] private bool newMove;
    [SerializeField] private bool newJump;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur entre dans la zone d'activation d'un block special, active les effets sur le joueur
        if (collision.name == "Player")
        {
            Player_Controller control = collision.gameObject.GetComponent<Player_Controller>();

            control.canMove = newMove;
            control.canJump = newJump;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Lorsque le joueur sort de la zone d'activation du block special, d�sactive les effets sur le joueur
        if (collision.name == "Player")
        {
            Player_Controller control = collision.gameObject.GetComponent<Player_Controller>();

            control.canMove = true;
            control.canJump = true;
        }
    }
}