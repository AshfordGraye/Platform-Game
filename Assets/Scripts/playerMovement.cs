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

    private float forceDrag;
    private float forceAngularDrag;

    private Rigidbody PlayerBody;
    private bool playerJumpEnabled;


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
        // print(playerJumpEnabled);
    }

    void PhysicsValues()
    {
        forceMove = 100;
        forceStrafe = 100;
        forceJump = 100;
        forceDrag = 0.5f;
        forceAngularDrag = 0.5f;
        // forceGrav = 0;
        // Physics.gravity = new UnityEngine.Vector3 (0,forceGrav,0);
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
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Panel_FloorSticky"))
        {
            playerJumpEnabled = false;
        }
        else if (collision.gameObject.CompareTag("Panel_FloorSlippy"))
        {
            PlayerBody.drag = 0.01f;
            PlayerBody.angularDrag = 0.01f;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        playerJumpEnabled = true;
        PlayerBody.drag = forceDrag;
        PlayerBody.angularDrag = forceAngularDrag;
    }
}
