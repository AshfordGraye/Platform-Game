using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceFloor : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.playerJumpEnabled = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Player.playerJumpEnabled = false;
    }
}
