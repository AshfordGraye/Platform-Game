using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class coinSpin : MonoBehaviour
{
    bool coinCollected = false;
    int forceSpin;

    void spinStandard()
    {
        forceSpin = 100;
        float forceSpinSpeed = forceSpin * Time.deltaTime;
        transform.Rotate(0, 0, forceSpinSpeed);
    }
    void spinCollected()
    {
        forceSpin = 300;
        float forceSpinSpeed = forceSpin * Time.deltaTime;
        transform.Rotate(0, 0, forceSpinSpeed);
    }

    void Update()
    {
        while (!coinCollected){
        spinStandard();
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
        }

    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
}