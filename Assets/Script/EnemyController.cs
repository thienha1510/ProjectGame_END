using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject player;
    private float speed = 0.05f;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * speed);
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
