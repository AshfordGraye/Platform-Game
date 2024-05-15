using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{



    public static Rigidbody PlayerBody;
    public static bool playerJumpEnabled;
    // BASE VALUES FOR PLAYER PHYSICS
    public static float baseforceMove = 100;
    public static int baseforceJump = 100;
    public static float baseforceDrag = 1f;
    public static float baseforceAngularDrag = 1f;
    //  PLAYER PHYSICS VALUES TO BE USED DURING PLAY. 
    public static float forceMove;
    public static int forceJump;
    void PhysicsValues()
    {
        // AT GAME START, SET VALUES TO DEFAULTS DETERMINED BY DIFFICULTY 
        forceMove = baseforceMove;
        forceJump = baseforceJump;
    }
    void MovePlayer()
    {
        UnityEngine.Vector3 movement = UnityEngine.Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new UnityEngine.Vector3(Input.GetAxis("Horizontal") * forceMove * Time.deltaTime, 0, Input.GetAxis("Vertical") * forceMove * Time.deltaTime);
        PlayerBody.AddForce(movement, ForceMode.Force);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Key Pressed");
            if (playerJumpEnabled)
            {
                PlayerBody.AddForce(UnityEngine.Vector3.up * forceJump, ForceMode.Force);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerBody = GetComponent<Rigidbody>();
        PhysicsValues();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
}