using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    private float checkHealthTime = 10f;
    private float timeBtwCheck = 10f;

    public int maxHealth;
    public int health;
    [SerializeField]
    private int numOfHearts;
    [SerializeField]
    private Image[] hearts;
    [SerializeField]
    private Sprite fullHeart;
    [SerializeField]
    private Sprite emptyHeart;
    [SerializeField]
    private GameObject heart;

    private Vector3 offset;
    private bool heartSpawned = false;
    public bool pickedHeart = false;

    void Update()
    {
        offset = new Vector3(2, 2,0);

        if((timeBtwCheck <= 0) && (!heartSpawned))
        {
            Instantiate(heart, transform.position + offset, Quaternion.identity);
            heartSpawned = true;
            timeBtwCheck = checkHealthTime;
        }
        else
        {
            timeBtwCheck -= Time.deltaTime;
        }

        if(pickedHeart)
        {
            health++;
            heartSpawned = false;
            pickedHeart = false;
        }

        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
