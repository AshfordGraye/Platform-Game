using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelect : MonoBehaviour
{
    public LifeSystem lifeSystem;
    public Player player;
    // public GameObject ButtonDiffEasy;
    // public GameObject ButtonDiffMid;
    // public GameObject ButtonDiffHard;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {

    }

    public void SetDifficulty()
    {
        Debug.Log("YA HIT ME");

        if (CompareTag("Diff_Easy"))
        {
            Player.playerLives = 5;
        }
        else if (CompareTag("Diff_Medium"))
        {
            Player.playerLives = 3;
        }
        else if (CompareTag("Diff_Hard"))
        {
            Player.playerLives = 1;
        }
        Debug.Log(Player.playerLives);
    }
}
