using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    void Start()
    {
        TurnManager.Instance.StarTurnCounder();
        ScoreManager.Instance.StartScorCound();
        CardManager.Instance.ShaffleSpawn();
    }

    public void GameWin()
    {
        UIManager.Instance.GameWinUI();
    }
    public void GameOver()
    {
        UIManager.Instance.GameOverUI();
    }
   
}
