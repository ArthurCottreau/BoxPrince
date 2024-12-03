using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// ChatGPT m'a aidé pour celui là, mais c'est bon c'est purement cosmétique :') - Emilien

public class CrownController : MonoBehaviour
{
    public Transform player;
    public float hoverDistance = 0.6f;
    public float fallSpeedFactor = 2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = fallSpeedFactor;
    }

    void Update()
    {
        // Horizontal position should always match the player
        Vector2 targetPosition = new Vector2(player.position.x, transform.position.y);
        transform.position = targetPosition;

        // Handle vertical positioning
        if (transform.position.y > player.position.y + hoverDistance)
        {
            // Allow gravity to act naturally with reduced gravity scale
            rb.gravityScale = fallSpeedFactor;
        }
        else
        {
            // Lock the crown above the player's head
            rb.gravityScale = 0f; // Disable gravity
            rb.velocity = Vector2.zero; // Stop any residual motion
            transform.position = new Vector2(player.position.x, player.position.y + hoverDistance);
        }
    }
}
