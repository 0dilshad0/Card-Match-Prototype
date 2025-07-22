using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TMP_Text TurnsCountText;
    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text ComboScoreText;

    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject GameWinScreen;
    [SerializeField] GameObject MenueScreen;

    [SerializeField] string UnlockLevel;

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

    public void UpdateScore(int score,int Combo)// Update score and combo score
    {
        ScoreText.text = score.ToString();
        ComboScoreText.text = $"+ {Combo}";
    }
    public void UpdateTurns(int turns)// Update number of turns/try
    {
        TurnsCountText.text = turns.ToString();
    }

    public void GameOverUI()
    {
        GameOverScreen.SetActive(true);
    }

    public void GameWinUI()
    {
        GameWinScreen.SetActive(true);
        if(UnlockLevel != null)
        {
            LevelManager.Instance.UnlockLevel(UnlockLevel);
        }
      
    }
}
