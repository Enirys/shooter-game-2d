using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private Collider2D projectileCollider;
    [SerializeField]
    private Collider2D playerCollider;

    public GameObject hitEffect;

    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(projectileCollider, playerCollider, true);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,target) < 0.2f)
        {
            
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
