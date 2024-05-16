using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using JetBrains.Annotations;
using Unity.VisualScripting;
// using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static void PhysicsValues()
    {
        // AT GAME START, SET VALUES TO DEFAULTS DETERMINED BY DIFFICULTY 
        Player.forceMove = Player.baseforceMove;
        Player.forceJump = Player.baseforceJump;
    }
    public static void MovePlayer()
    {
        UnityEngine.Vector3 movement = UnityEngine.Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new UnityEngine.Vector3(Input.GetAxis("Horizontal") * Player.forceMove * Time.deltaTime, 0, Input.GetAxis("Vertical") * Player.forceMove * Time.deltaTime);
        Player.PlayerBody.AddForce(movement, ForceMode.Force);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Key Pressed");
            if (Player.playerJumpEnabled)
            {
                Player.PlayerBody.AddForce(UnityEngine.Vector3.up * Player.forceJump, ForceMode.Force);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Jump"))
        {
            Player.playerJumpEnabled = true;
            Debug.Log(collision.gameObject.tag);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Contains("Jump"))
        {
            Player.playerJumpEnabled = false;
        }
    }
}