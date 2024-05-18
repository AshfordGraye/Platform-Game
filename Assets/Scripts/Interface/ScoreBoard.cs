using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour

{

    // PLAYER SCORE VALUES
    public int scoreCurrent; // points from coins
    public int scoreFinal; // points from coins + time - used at stage end
    public Text scoreDisplay; // Text component to display the score
    void BaseStats()
    {
        scoreCurrent = 0;
        scoreFinal = 0;
    }

    // UpdateScoreText is called by coin objects when triggered. 
    public void UpdateScoreText()

    {
        scoreDisplay.text = "Points: " + scoreCurrent; // Update text component
    }

    // Start is called before the first frame update
    void Start()
    {
        BaseStats();
        UpdateScoreText(); // Update score text at start
    }
}