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

    void Start()
    {
        CurrentTurn = MaxTurn;
        UIManager.Instance.UpdateTurns(CurrentTurn);
    }

    public void UseTurn()
    {
        if(CurrentTurn>0)
        {
            CurrentTurn--;
            UIManager.Instance.UpdateTurns(CurrentTurn);
        }
        else
        {
            UIManager.Instance.GameOver();
            AudioManager.Instance.PlayOverSFX();
        }
       
    }
}
