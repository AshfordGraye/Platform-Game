using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceSlippy : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.forceMove = 200;
            // Reduce player drag values to simulate a slippy surface.
            Player.PlayerBody.drag = 1f;
            Player.PlayerBody.angularDrag = 1f;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Reset player drag values to standard
        Player.forceMove = Player.baseforceMove;
        Player.PlayerBody.drag = Player.baseforceDrag;
        Player.PlayerBody.angularDrag = Player.baseforceAngularDrag;
    }
}