using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class surfaceStageGoal : MonoBehaviour
{
    public GameObject Interface_LevelComplete;
    public GameObject Score;
    public GameObject Lives;
    public ScoreSystem scoreSystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            Interface_LevelComplete.SetActive(true);
            Score.SetActive(false);
            Lives.SetActive(false);
            scoreSystem.FinalScoreText();
        }
    }
}
