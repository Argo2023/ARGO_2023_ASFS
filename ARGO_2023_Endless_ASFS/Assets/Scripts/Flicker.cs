using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public SpriteRenderer sprite;
    /// <summary>
    /// flicker just starts the hurt flicker coroutine
    /// </summary>
    public void flicker()
    { StartCoroutine(hurtFlicker()); }

    /// <summary>
    /// This is attached to a sprite
    /// the sprite is flickered between black red and white with small gaps in between.
    /// This is called when the sprite is hurt by something.
    /// </summary>
    /// <returns></returns>
    IEnumerator hurtFlicker()
    {

        sprite.color = (Color.black);
        yield return new WaitForSeconds(0.05f);
        sprite.color = (Color.red);
        yield return new WaitForSeconds(0.05f);
        sprite.color = (Color.white);
    }
}
