using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public SpriteRenderer sprite;
    public void flicker()
    { StartCoroutine(hurtFlicker()); }

    IEnumerator hurtFlicker()
    {

        sprite.color = (Color.black);
        yield return new WaitForSeconds(0.05f);
        sprite.color = (Color.red);
        yield return new WaitForSeconds(0.05f);
        sprite.color = (Color.white);
    }
}
