using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    [SerializeField] private int MaxTurn;

    private int CurrentTurn;

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

    public void StarTurnCounder()
    {
        CurrentTurn = MaxTurn;
        UIManager.Instance.UpdateTurns(CurrentTurn);
    }

    public void UseTurn() // calculate number of turn/try
    {
        CurrentTurn--;
        UIManager.Instance.UpdateTurns(CurrentTurn);
        if (CurrentTurn<=0)
        { 
            GameManager.Instance.GameOver();
            AudioManager.Instance.PlayOverSFX();
        }
             
    }
}
