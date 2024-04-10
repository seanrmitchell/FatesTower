using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject lostPanel;
    public GameObject wonPanel;
    public GameObject fortunePanel;

    public void OnDeath(string type)
    {
        if (type.Equals("Player"))
        {
            fortunePanel.SetActive(false);
            lostPanel.SetActive(true);
        }
        else
        {
            fortunePanel.SetActive(false);
            wonPanel.SetActive(true);
        }
    }
}
