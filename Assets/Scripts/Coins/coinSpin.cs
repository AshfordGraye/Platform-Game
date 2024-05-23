using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.UIElements;

public class coinSpin : MonoBehaviour
{
    public ScoreSystem playerScore;
    private MeshCollider coinCollider;
    bool coinCollected = false;
    float coinLifted = 0;
    int coinTurn;
    void spinStandard()
    {
        coinTurn = 100;
        float coinTurnSpeed = coinTurn * Time.deltaTime;
        transform.Rotate(0, 0, coinTurnSpeed);
    }
    void spinCollected()
    {
        if (coinLifted < 5)
        {
            coinLifted += 0.02f;
            coinTurn = 2000;
            float coinTurnSpeed = coinTurn * Time.deltaTime;
            transform.Rotate(0, 0, coinTurnSpeed);
            var forceLift = 2 * Time.deltaTime;
            transform.Translate(0, 0, -forceLift);
        }
        else{
            DestroyCoin();
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinCollider.enabled = false;
            if (gameObject.CompareTag("Coin_Bronze"))
            {
                coinCollected = true;
                playerScore.scoreCurrent += 5;
                Debug.Log(Player.scoreCurrent);
                spinCollected();
            }
            else if (gameObject.CompareTag("Coin_Silver"))
            {
                coinCollected = true;
                playerScore.scoreCurrent += 10;
                Debug.Log(Player.scoreCurrent);
                spinCollected();
            }
            else if (gameObject.CompareTag("Coin_Gold"))
            {
                coinCollected = true;
                playerScore.scoreCurrent += 20;
                Debug.Log(Player.scoreCurrent);
                spinCollected();
            }
            playerScore.UpdateScoreText();
        }
    }

    void DestroyCoin(){
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        coinCollider = GetComponent<MeshCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!coinCollected)
        {
            spinStandard();
        }
        else
        {
            spinCollected();
        }
    }
}