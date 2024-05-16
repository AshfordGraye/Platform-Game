using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
// using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class coinSpin : MonoBehaviour
{
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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Coin_Bronze"))
            {
                coinCollected = true;
                Player.scoreCurrent += 5;
                Debug.Log(Player.scoreCurrent);
                spinCollected();
            }
            if (gameObject.CompareTag("Coin_Silver"))
            {
                coinCollected = true;
                Player.scoreCurrent += 10;
                Debug.Log(Player.scoreCurrent);
                spinCollected();
            }
            if (gameObject.CompareTag("Coin_Gold"))
            {
                coinCollected = true;
                Player.scoreCurrent += 20;
                Debug.Log(Player.scoreCurrent);
                spinCollected();
            }
        }
    }

    void DestroyCoin(){
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
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