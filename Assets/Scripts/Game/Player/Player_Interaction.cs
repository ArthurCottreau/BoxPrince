using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    [SerializeField] private Player_Controller control;
    [SerializeField] private LayerMask layermask;
    private Rigidbody2D player_rb;
    private BoxCollider2D player_coll;

    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        player_coll = GetComponent<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        RaycastHit2D hit_rb = Physics2D.BoxCast(player_coll.bounds.center, player_coll.bounds.size, 0f, Vector2.down, 0.05f, layermask); // setup Raycast sous le joueur
        if (hit_rb.collider != null) // Check si le Raycast a touché quelque chose
        {
            string tag = hit_rb.collider.tag; // set une variable égal au tag de l'objet touché
            if (tag == "Ice")
            {
                control.canJump = false;
                control.canMove = true;
                //Debug.Log("Ice");
            }
            else if (tag == "Mud")
            {
                control.canJump = true;
                control.canMove = false;
                //Debug.Log("Mud");
            }
            else if (tag == "Slope") // pour l'instant redondant avec Ice, en attendant des modifs
            {
                control.canJump = false;
                control.canMove = true;
                //Debug.Log("Slope");

            }
            else if (tag == "Spike")
            {
                Death();
            }
            else
            {
                control.canJump = true;
                control.canMove = true;
                //Debug.Log("Platform");
            }
        }
        else // tag == null || Untagged
        {
            control.canJump = true;
            control.canMove = true;
            //Debug.Log("Nothing lol");
        }

    }
    public void Death() //la fonction fait pas grand chose pour l'instant.
    {
        if (control.isDead == false)
        {
            Debug.Log("You are dead!");
            control.isDead = true;
        }

    }
}
