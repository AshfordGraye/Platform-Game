using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceSlippy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.PlayerBody.drag = 0.01f;
            Player.PlayerBody.angularDrag = 0.01f;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Player.PlayerBody.drag = Player.baseforceDrag;
        Player.PlayerBody.angularDrag = Player.baseforceAngularDrag;
    }
}