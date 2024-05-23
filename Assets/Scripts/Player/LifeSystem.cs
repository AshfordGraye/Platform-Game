using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour

{

    // PLAYER SCORE VALUES

    public Player player;
    public Text livesDisplay; // Text component to display the score

    // UpdateScoreText is called by coin objects when triggered. 
    public void UpdateScoreText()

    {
        livesDisplay.text = Player.playerLives + " | Lives"; // Update text component
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText(); // Update score text at start
    }
}