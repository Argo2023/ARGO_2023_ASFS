using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleResetJump : MonoBehaviour
{
    public singlePlayerScript player;

    /// <summary>
    /// Checks if the player has returned to the ground after jumping.
    /// If this has happened, set grounded to true, reset the jumpCount
    /// and also set the animation for player jumping to false
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            player.createDust();
            player.isGrounded = true;
            player.jumpCount = 0;
        }
        else if(collision.gameObject.CompareTag("Platform"))
        {
            player.createDust();
            player.isGrounded = true;
            player.jumpCount = 0;
        }
    }

}
