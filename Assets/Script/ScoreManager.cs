using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int ComboScore = 1;
    private int score;
    private int TottalCards;
    
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

    private void Start()
    {
        updateCombo();
    }

    public void AddScore()
    {
        TottalCards++;
        score = score + ComboScore;
        updateCombo();
    }

    public void updateCombo()
    {
        UIManager.Instance.UpdateScore(score, ComboScore);
    }


    public void CheckIsWin(int row,int col)
    {
        if((row*col)/2 == TottalCards)
        {
            AudioManager.Instance.PlayWinSFX();
            UIManager.Instance.GameWin();
           
        }
    }
}
