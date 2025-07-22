using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public TMP_Text TurnsCountText;
    public int MaxTurn;
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
        TurnsCountText.text = CurrentTurn.ToString();
    }

    public void UseTurn()
    {
        CurrentTurn--;
        TurnsCountText.text = CurrentTurn.ToString();
    }
}
