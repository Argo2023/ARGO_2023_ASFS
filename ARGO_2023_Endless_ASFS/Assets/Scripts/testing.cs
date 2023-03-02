using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    public bool OnOff = false;
    public GameObject bloodEffect;
    public Transform fp1;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    /// <summary>
    /// spawns blood spurting out of the thing thath is hit
    /// </summary>
    void Update()
    {
        
        if(OnOff == true)
        {
            for (int i = 0; i < 5; i++)
            {
                Vector2 randomDirection = Random.insideUnitCircle.normalized;
                GameObject blood = Instantiate(bloodEffect, fp1.position, Quaternion.identity);
                Rigidbody2D rbBlood = blood.GetComponent<Rigidbody2D>();
                rbBlood.AddForce(randomDirection * 2, ForceMode2D.Impulse);
                Destroy(blood, 20.0f);
            }
            OnOff = false;
        }
    }
}
