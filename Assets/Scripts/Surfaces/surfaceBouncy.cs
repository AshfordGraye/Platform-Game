using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceBouncy : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.forceJump = 200;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        Player.forceJump = Player.baseforceJump;
    }
}

