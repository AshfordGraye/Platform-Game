using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class surfaceSticky : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")){
            Player.playerJumpEnabled = false;
        }
    }

    // NO COLLISION EXIT REQUIRED - PLAYER MUST MAKE CONTACT WITH ANOTHER VALID SURFACE PANEL TO RE-ENABLE JUMP
}
