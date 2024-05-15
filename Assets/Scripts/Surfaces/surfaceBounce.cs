using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surfaceBounce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            Player.playerJumpEnabled = true;
            Player.forceJump = Player.forceJump * 2;
            Debug.Log(Player.forceJump);
        }
    }
        void OnCollisionExit(Collision collision){
        if(collision.gameObject.CompareTag("Player")){
            Player.playerJumpEnabled = false;
            Player.forceJump = Player.baseforceJump;
            Debug.Log(Player.baseforceJump);
        }
    }
}
