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
    float collectionAnimation = 0;
    int coinTurn;
    void spinStandard()
    {
        coinTurn = 100;
        float coinTurnSpeed = coinTurn * Time.deltaTime;
        transform.Rotate(0, coinTurnSpeed, 0);
    }
    void spinCollected()
    {
        var fromScale = transform.root.localScale;
        Vector3 toScale = Vector3.zero;
        if (collectionAnimation < 1)
        {
            collectionAnimation += 0.02f;
            coinTurn = 2000;
            float coinTurnSpeed = coinTurn * Time.deltaTime;
            transform.Rotate(0, coinTurnSpeed, 0);


            transform.localScale = Vector3.Scale(transform.localScale,new Vector3(0.1f,0.1f,0.1f));
        }
        else
        {
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

    void DestroyCoin()
    {
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