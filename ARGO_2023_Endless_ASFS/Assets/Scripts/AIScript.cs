using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AIState
{
    IDLE,
    ATTACKING,
    CHASING,
    EVADING,
    HIDING
};


public class AIScript : MonoBehaviour
{
    AIState state = AIState.IDLE;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthScript>().initializePlayer(100, 10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
