using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speedMove;
    [SerializeField] float speedStrafe;

    // Start is called before the first frame update
    void Start()
    {
        PhysicsValues();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PhysicsValues()
    {
        speedMove = 2000;
        speedStrafe = 2000;
        Physics.gravity = new UnityEngine.Vector3 (0,-500,0);
    }

    void MovePlayer()
    {
        // float playerForwardBack = Input.GetAxis("Vertical") * Time.deltaTime * speedMove;
        // transform.Translate(0, 0, playerForwardBack);
        // float playerTurn = Input.GetAxis("Horizontal") * Time.deltaTime * speedTurn;
        // transform.Rotate(0, playerTurn, 0);
        // float playerStrafe = Input.GetAxis("Horizontal") * Time.deltaTime * speedStrafe;
        // transform.Translate(playerStrafe, 0, 0);

        var Player = GetComponent<Rigidbody>();
        UnityEngine.Vector3 movement = UnityEngine.Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new UnityEngine.Vector3(Input.GetAxis("Horizontal") * speedStrafe * Time.deltaTime, 0, Input.GetAxis("Vertical") * speedMove * Time.deltaTime);
        Player.velocity = movement;
    }
}
