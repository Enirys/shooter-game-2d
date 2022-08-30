using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerHealth playerH;
    private Player player;

    public GameObject deathEffect;
    public int score;

    public GameObject boss;
    public bool bossIsDead = false;

    public Text scoreText;

    public bool gameOver = false;
    private bool levelComplete = false;

    public GameObject gameOverPanel;
    public GameObject gamePanel;
    public GameObject gameCompletePanel;
    public GameObject instructionPanel;

    private float insctructionTimer = 3f;
    public bool gameStarted = false;

    private void Start()
    {
        playerH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(insctructionTimer <= 0)
        {
            gameStarted = true;
            instructionPanel.SetActive(false);
        }
        else
        {
            insctructionTimer -= Time.deltaTime;
        }
        
        if(gameStarted)
        {
            if(boss != null)
            {
                boss.SetActive(true);
            }
            if (bossIsDead)
            {
                levelComplete = true;
            }

            if (score > 200 && boss == null)
            {
                levelComplete = true;
            }

            if (levelComplete)
            {
                gameCompletePanel.SetActive(true);
                gamePanel.SetActive(false);
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            }

            if (!gameOver)
            {
                scoreText.text = score.ToString();
            }

            if (playerH.health <= 0)
            {
                if (boss != null)
                {
                    boss.SetActive(false);
                }

                gameOver = true;
                gamePanel.SetActive(false);
                gameOverPanel.SetActive(true);
                if (player != null)
                {
                    Instantiate(deathEffect, transform.position, Quaternion.identity);
                    Destroy(player.gameObject);
                }
                Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            }
        }

        
    }
}
