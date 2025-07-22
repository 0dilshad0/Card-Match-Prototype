using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    [SerializeField] private Sprite[] sprits;
    [SerializeField] private GameObject CardPrefab;
    [SerializeField] private Transform Container;
    [SerializeField] private int rows;
    [SerializeField] private int cols;

    private List<Sprite> Sprits = new();
    private List<Card> SelectedCards = new();

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
    public void ShaffleSpawn()
    {
        for (int i = 0; i < (rows * cols) / 2; i++)//shaffle card position
        {
            Sprits.Add(sprits[i]);
            Sprits.Add(sprits[i]);
        }

        for (int i = 0; i < Sprits.Count; i++)
        {
            int randomIndex = Random.Range(i, Sprits.Count);
            Sprite temp = Sprits[i];
            Sprits[i] = Sprits[randomIndex];
            Sprits[randomIndex] = temp;
        }

        for (int i = 0; i < rows * cols; i++)   //spawn cards
        {
            GameObject newCard = Instantiate(CardPrefab, Container);

            Card card = newCard.GetComponent<Card>();
            card.CardSprite = Sprits[i];

            card.SetIcon();
        }

    }

    public void SelectCard(Card card)//select card
    {
        AudioManager.Instance.PlayFlipSFX();
        card.Show();
        SelectedCards.Add(card);

        if(SelectedCards.Count >=2)
        {
            StartCoroutine(Check(SelectedCards[0], SelectedCards[1]));
            SelectedCards.Clear();
        }

    }

    IEnumerator Check(Card card1, Card card2)//Campare cards
    {
        yield return new WaitForSeconds(0.5f);
        if (card1.CardSprite == card2.CardSprite)//
        {
            card1.Match();
            card2.Match();
            ScoreManager.Instance.ComboScore++;
            ScoreManager.Instance.AddScore();
            ScoreManager.Instance.CheckIsWin(rows,cols);
            AudioManager.Instance.PlayMatchSFX();
        }
        else                                     //Not match 
        {
            card1.Hide();
            card2.Hide();
            ScoreManager.Instance.ComboScore = 1;
            ScoreManager.Instance.updateCombo();
            AudioManager.Instance.PlayFlipSFX();
          
        }
        TurnManager.Instance.UseTurn();
       
    }
}
