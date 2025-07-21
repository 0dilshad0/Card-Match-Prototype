using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    public Sprite[] sprits;
    public GameObject CardPrefab;
    public Transform Container;
    public int rows;
    public int cols;

    private List<Sprite> Sprits = new();
    private Card FirstCard;
    private Card SecondCard;

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
        Shuffle();
        Spawn();
    }

    private void Shuffle()
    {
        for (int i = 0; i < (rows * cols) / 2; i++)
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

    }

    private void Spawn()
    {

        for (int i = 0; i < rows * cols; i++)
        {
            GameObject newCard = Instantiate(CardPrefab, Container);
      
            Card card = newCard.GetComponent<Card>();
            card.CardSprite = Sprits[i];
        }
    }

    public void SelectCard(Card card)
    {
        if(!card.IsSelected)
        {
            card.Show();

            if(FirstCard == null)
            {
                FirstCard = card;
                return;
            }

            if(SecondCard == null)
            {
                SecondCard = card;
                StartCoroutine(Check(FirstCard,SecondCard));
            }

        }
    }

    IEnumerator Check(Card card1, Card card2)
    {
        yield return new WaitForSeconds(0.5f);
        if (card1.CardSprite == card2.CardSprite)
        {

        }
        else
        {
            card1.Hide();
            card2.Hide();
        }
        FirstCard = null;
        SecondCard = null;
    }
}
