using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject Back;
    
    void Start()
    {
        Invoke("Hide",1f);
    }

    public void Show()
    {
        Back.SetActive(false);
    }
    public void Hide()
    {
        Back.SetActive(true);
    }

}
