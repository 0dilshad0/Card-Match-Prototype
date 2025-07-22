using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unloked : MonoBehaviour
{

    [SerializeField] private Image Medium;
    [SerializeField] private Image Hard;

    void Start()
    {
        Check();
    }

    public void Check()
    {
        if (!LevelManager.Instance.CheckISUnlocked("Medium"))
        {
            Medium.color = Color.gray;
        }
        if (!LevelManager.Instance.CheckISUnlocked("Hard"))
        {
            Hard.color = Color.gray;
        }
    }

   
}
