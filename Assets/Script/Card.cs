using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject Icon;
    public Sprite CardSprite;
    public Animator CardAnimator;
    private bool IsSelected;
    private bool IsMatched;
    
    

    void Start()
    {
        
        Image cardImage = Icon.GetComponent<Image>();
        cardImage.sprite = CardSprite;

       
        Invoke("Hide",1f);
    }


    public void Select()
    {
        if(!IsSelected && !IsSelected)
        CardManager.Instance.SelectCard(this);
    }
    public void Show()
    {
        CardAnimator.SetTrigger("Pressed");
        IsSelected = true;
        Invoke("CardShow",0.2f);
    }

    private void CardShow()
    {
        Icon.SetActive(true);
    }

    public void Hide()
    { 
        IsSelected = false;
        CardAnimator.SetTrigger("Pressed");
        Invoke("CardHide", 0.2f);
    }
    private void CardHide()
    {
        Icon.SetActive(false);
    }

    public void Match()
    {
        IsSelected = true;

        Image BackImage = GetComponent<Image>();
        BackImage.enabled = false;

        Image IconImage = Icon.GetComponent<Image>();
        IconImage.enabled = false;
    }
}
