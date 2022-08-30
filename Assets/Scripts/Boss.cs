using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public GameObject deathEffect;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject enemyProjectile;

    private GameManager gm;

    public float health;
    public Slider healthBar;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.gameStarted)
        {
            healthBar.value = health;

            if (player != null)
            {
                if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
                {
                    transform.position = this.transform.position;
                }
                else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                }
            }

            if (timeBtwShots <= 0)
            {
                Instantiate(enemyProjectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

            if (health <= 0)
            {
                gm.bossIsDead = true;
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            if(health > 0)
            {
                gm.score += 5;
                health--;
            }
        }
    }
}
