using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using JetBrains.Annotations;
using Unity.VisualScripting;
// using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    //  PLAYER BODY PROPERTIES
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

    public static float forceDrag;
    public static float forceAngularDrag;

    public static bool playerInContact;

    // PLAYER SCORE VALUES
    public static int scoreCurrent;
    public static int scoreFinal;
    public static int playerLives;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PlayerBody = GetComponent<Rigidbody>();
        PlayerMovement.PhysicsValues();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement.MovePlayer();
    }
}