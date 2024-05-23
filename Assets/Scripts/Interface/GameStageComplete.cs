using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStageComplete : MonoBehaviour
{
    public ScoreSystem scoreSystem;
    // Start is called before the first frame update
    void Start()
    {
        scoreSystem.FinalScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
