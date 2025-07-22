using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    private int score;

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

    public void AddScore(int point)
    {
        score = score + point;
        UIManager.Instance.UpdateScore(score);
    }
    public void CheckIsWin(int row,int col)
    {
        if((row*col)/2 == score)
        {
            AudioManager.Instance.PlayWinSFX();
            UIManager.Instance.GameWin();
           
        }
    }
}
