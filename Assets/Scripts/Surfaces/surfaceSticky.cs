using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
// using UnityEditor;
using UnityEngine;

public class surfaceSticky : MonoBehaviour
{
    void OnCollisionStay(Collision collision){
            Player.forceJump = 75;
    }
    void OnCollisionExit(Collision collision)
    {
        Player.forceJump = Player.baseforceJump;
    }
}
