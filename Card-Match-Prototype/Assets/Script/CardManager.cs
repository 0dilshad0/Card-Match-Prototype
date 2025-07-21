using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public Sprite[] sprits;
    public GameObject CardPrefab;
    public Transform Container;
    public int rows;
    public int cols;

    private List<Sprite> Cards = new();

    void Start()
    {
        for (int i = 0; i < (rows * cols)/2; i++)
        {
            Cards.Add(sprits[i]);
            Cards.Add(sprits[i]);
        }

        for (int i = 0; i < Cards.Count; i++)
        {
            int randomIndex = Random.Range(i, Cards.Count);
            Sprite temp = Cards[i];
            Cards[i] = Cards[randomIndex];
            Cards[randomIndex] = temp;
        }

        for (int i = 0;i<rows*cols;i++)
        {         
           GameObject newCard =Instantiate(CardPrefab,Container);
           Image cardImage = newCard.GetComponent<Image>();

            cardImage.sprite = Cards[i];
        }    
    }

    
    void Update()
    {
        
    }
}
