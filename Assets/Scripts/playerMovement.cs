using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speedMove;
    [SerializeField] float speedTurn;
    [SerializeField] float speedStrafe;

    // Start is called before the first frame update
    void Start()
    {
        speedMove = 10;
        speedTurn = 100;
        speedStrafe = 10;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float playerForwardBack = Input.GetAxis("Vertical") * Time.deltaTime * speedMove;
        transform.Translate(0, 0, playerForwardBack);
        float playerTurn = Input.GetAxis("Horizontal") * Time.deltaTime * speedTurn;
        // transform.Rotate(0, playerTurn, 0);
        float playerStrafe = Input.GetAxis("Horizontal") * Time.deltaTime * speedStrafe;
        transform.Translate(playerStrafe, 0, 0);
    }


}
