using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject Icon;
    public bool IsSelected;

    public Sprite CardSprite;
    void Start()
    {

        Image cardImage = Icon.GetComponent<Image>();
        cardImage.sprite = CardSprite;

        Show();
        Invoke("Hide",1f);
    }


    public void Select()
    {
        CardManager.Instance.SelectCard(this);
    }
    public void Show()
    {
        Icon.SetActive(true);
        IsSelected = true;
    }
    public void Hide()
    {
        Icon.SetActive(false);
        IsSelected = false;
    }

}
