using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadEasy()
    {
        SceneManager.LoadScene("Easy");
    }
    public void LoadMeadium()
    {
        SceneManager.LoadScene("Medium");
    }  public void LoadHard()
    {
        SceneManager.LoadScene("Hard");
    }
    public void Back()
    {
        SceneManager.LoadScene("Home");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
