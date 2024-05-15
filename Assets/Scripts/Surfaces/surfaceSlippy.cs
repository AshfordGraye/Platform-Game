using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceSlippy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduce player drag values to simulate a slippy surface.
            Player.PlayerBody.drag = 0.01f;
            Player.PlayerBody.angularDrag = 0.01f;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Reset player drag values to standard
        Player.PlayerBody.drag = Player.baseforceDrag;
        Player.PlayerBody.angularDrag = Player.baseforceAngularDrag;
    }
}