using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TMP_Text TurnsCountText;
    [SerializeField] private TMP_Text ScoreText;

    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject GameWinScreen;
    [SerializeField] GameObject MenueScreen;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }
    public void UpdateTurns(int turns)
    {
        TurnsCountText.text = turns.ToString();
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void GameWin()
    {
        GameWinScreen.SetActive(true);
    }

    public void Back()
    {

    }

    public void Retry()
    {

    }
}
