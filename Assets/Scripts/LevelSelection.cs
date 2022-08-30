using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void SnowLevel()
    {
        SceneManager.LoadScene(2);
    }

    public void ForestLevel()
    {
        SceneManager.LoadScene(3);
    }

    public void FinalLevel()
    {
        SceneManager.LoadScene(4);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
