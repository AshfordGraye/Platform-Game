using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using JetBrains.Annotations;
using Unity.VisualScripting;

// using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    int countdownTimer;
    public LifeSystem lifeSystem;
    public Player player;
    public static void PhysicsValues()
    {
        // AT GAME START, SET VALUES TO DEFAULTS DETERMINED BY DIFFICULTY 
        Player.forceMove = Player.baseforceMove;
        Player.forceJump = Player.baseforceJump;
        Player.PlayerBody.drag = Player.baseforceDrag;
        Player.PlayerBody.angularDrag = Player.baseforceAngularDrag;
    }
    public static void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            // Debug.Log("W key pressed to go forward");
        }
        UnityEngine.Vector3 movement = UnityEngine.Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new UnityEngine.Vector3(Input.GetAxis("Horizontal") * Player.forceMove * Time.deltaTime, 0, Input.GetAxis("Vertical") * Player.forceMove * Time.deltaTime);
        Player.PlayerBody.AddForce(movement, ForceMode.Force);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Space Key Pressed");
            if (Player.playerJumpEnabled)
            {
                Player.PlayerBody.AddForce(UnityEngine.Vector3.up * Player.forceJump, ForceMode.Force);
            }
        }
    }
    void OnCollisionStay(Collision collision)
    {
        countdownTimer = 0;
        Player.playerInContact = true;
        if (collision.gameObject.tag.Contains("Floor"))
        {
            // Debug.Log( Player.playerInContact + "Player in contact with floor");
            Player.playerJumpEnabled = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        Player.playerInContact = false;
        if (collision.gameObject.tag.Contains("Floor"))
        {
            Player.playerJumpEnabled = false;
        }
        PlayerFallCountdown();
    }
    void PlayerFallCountdown()
    {
        
        if (Player.playerInContact == false)
        {
            if (countdownTimer != 5)
            {
                countdownTimer += 1;
                // Debug.Log(countdownTimer);
                Invoke("PlayerFallCountdown", 1);
            }
            else if (countdownTimer == 5){
                // Debug.Log("Player has died");
                Player.playerLives -=1;
                // Debug.Log(Player.playerLives);
                if (Player.playerLives == 0){
                    SceneManager.LoadScene("MenuGameOver");
                }
                else {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}