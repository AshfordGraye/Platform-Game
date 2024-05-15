using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceSlippy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // to re-enable jump if moving from a sticky surface
            Player.playerJumpEnabled = true; 
            // Reduce player drag values to simulate a slippy surface.
            Player.PlayerBody.drag = 0.01f;
            Player.PlayerBody.angularDrag = 0.01f;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // to avoid being able to jump in midair. Next valid surface panel contacted by player will decide if jump is re-enabled
        Player.playerJumpEnabled = false;
        // Reset player drag values to standard
        Player.PlayerBody.drag = Player.baseforceDrag;
        Player.PlayerBody.angularDrag = Player.baseforceAngularDrag;
    }
}