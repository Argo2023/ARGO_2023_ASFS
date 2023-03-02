using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    [SerializeField]
    public float speed = 0;
    private Material material;
    private float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        // width = transform.localScale.x;
        material = GetComponent<Renderer>().material;
        speed = 0;
        offsetX = 0f;
    }

    /// <summary>
    /// In the update we scroll the texture so it looks like its moving to the side.
    /// </summary>
    void FixedUpdate()
    {
        if (speed < 0.06)
        {
            speed += 0.00001f;                                                            
        }
        offsetX += Time.deltaTime * speed;
        material.mainTextureOffset = new Vector2(offsetX, 0);

        if (offsetX > 1f)
        {
            offsetX -= 1f;
        }

    }

}