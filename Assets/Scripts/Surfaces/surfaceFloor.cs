using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceFloor : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Enable jump if moving from a sticky surface
            Player.playerJumpEnabled = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // To avoid being able to jump in midair. Next valid surface panel contacted by player will decide if jump is re-enabled
        Player.playerJumpEnabled = false; 
    }
}
