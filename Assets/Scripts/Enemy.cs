using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gm;

    public int health;

    public float speed;
    private GameObject target;
    private Transform playerPos;
    public GameObject deathEffect;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();

        target = GameObject.Find("Player");
        if(target != null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            health--;
            Destroy(collision.gameObject);
            if(health <= 0)
            {
                gm.score += 5;
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
        }
    }
}
