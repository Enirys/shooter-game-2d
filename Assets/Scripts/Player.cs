using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHealth player;

    public GameObject heartEffect;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            if (player.health > 0)
            {
                player.health--;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Heart"))
        {
            Instantiate(heartEffect, transform.position, Quaternion.identity);
            player.pickedHeart = true;
            
        }
    }
}
