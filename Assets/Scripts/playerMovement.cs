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

    [SerializeField] float forceMove;
    [SerializeField] float forceStrafe;

    [SerializeField] int forceGrav;
    [SerializeField] int forceJump;


    public static Rigidbody PlayerBody;
    public static bool playerJumpEnabled;
    public static float baseforceDrag = 0.5f;
    public static float baseforceAngularDrag = 0.5f;


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

    void PhysicsValues()
    {
        forceMove = 100;
        forceStrafe = 100;
        forceJump = 100;
    }

    void MovePlayer()
    {
        UnityEngine.Vector3 movement = UnityEngine.Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new UnityEngine.Vector3(Input.GetAxis("Horizontal") * forceStrafe * Time.deltaTime, 0, Input.GetAxis("Vertical") * forceMove * Time.deltaTime);
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
}
