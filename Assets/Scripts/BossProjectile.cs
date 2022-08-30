using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public float speed;
    private Transform player;
    private float timeBtwDestroy;
    public float lifeTime;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwDestroy = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, player.transform.position) < 0.2f)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if(timeBtwDestroy <= 0)
            {
                Instantiate(hitEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                timeBtwDestroy -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
