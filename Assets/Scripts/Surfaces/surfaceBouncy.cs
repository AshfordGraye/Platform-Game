using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceBouncy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.forceJump = Player.forceJump * 2;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        Player.forceJump = Player.baseforceJump;
    }
}

