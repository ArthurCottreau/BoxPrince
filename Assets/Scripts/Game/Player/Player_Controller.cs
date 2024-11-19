using System.Collections;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Variables li�es aux stats du joueur
    [SerializeField] private float speed;   // Vitesse de d�placement
    [SerializeField] private float jump_force;  // Puissance du saut
    [SerializeField] private float jump_length; // Dur�e du saut
    [SerializeField] private float jbuffer_length;  // Dur�e avant d'avoir touch� le sol, o� le saut est toujours consid�r� valide
    [SerializeField] private float coyote_lenght;   // Dur�e du coyote time

    // Variables qui r�cup�rent des �l�ments externes
    private Rigidbody2D player_rb;
    private BoxCollider2D player_coll;
    [SerializeField] private LayerMask layermask;

    // Variables qui servent � g�rer le saut
    private bool is_jumping = false;
    private float jump_timer = 0;
    private float coyote_timer = 0;
    private float jbuffer_timer = 0;

    // Variables li�es aux contr�les
    private float x_input;
    private bool press_jump = false;
    private bool pressing_jump = false;

    void Start()
    {
        player_rb = GetComponent<Rigidbody2D>();
        player_coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        x_input = Input.GetAxis("Horizontal");
        pressing_jump = Input.GetKey(KeyCode.UpArrow);
        if (Input.GetKeyDown(KeyCode.UpArrow)) press_jump = true;
    }

    void FixedUpdate()
    {
        handle_movement();
        handle_jump();
    }

    private void handle_movement()
    {
        player_rb.velocity = new Vector2(x_input * speed, player_rb.velocity.y);
    }

    private void handle_jump()
    {
        // Si le joueur touche le sol
        if (is_Touching(Vector2.down))
        {
            coyote_timer = coyote_lenght;
        }
        else
        {
            coyote_timer -= Time.deltaTime;
        }

        // Si le joueur vient juste d'appuyer sur la touche saut
        if (press_jump)
        {
            press_jump = false;
            jbuffer_timer = jbuffer_length;
        }

        // V�rifie si le joueur peut sauter
        if(jbuffer_timer > 0)
        {
            jbuffer_timer -= Time.deltaTime;

            if (coyote_timer > 0)
            {
                is_jumping = true;
                jump_timer = jump_length;
                coyote_timer = 0; 
            }
        }

        if (is_jumping)
        {
            // Applique la physique du saut lors de la dur�e du 'jump_timer'
            if (jump_timer > 0)
            {
                player_rb.velocity = new Vector2(player_rb.velocity.x, jump_force);
            }

            jump_timer -= Time.deltaTime;

            // Si le joueur lache la touche saut ou touche le plafond
            if (!pressing_jump || is_Touching(Vector2.up))
            {
                is_jumping = false;
                jump_timer = 0;
            }
        }
    }

    private bool is_Touching(Vector2 direction)
    {
        RaycastHit2D raycast = Physics2D.BoxCast(player_coll.bounds.center, player_coll.bounds.size, 0f, direction, 0.05f, layermask);
        return raycast.collider != null;
    }
}
