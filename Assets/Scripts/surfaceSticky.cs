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

    void OnCollisionExit (Collision collision){
        Player.playerJumpEnabled=true;
    }
}
