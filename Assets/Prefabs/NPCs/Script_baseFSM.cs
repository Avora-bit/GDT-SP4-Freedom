using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_baseFSM : MonoBehaviour
{
    enum FSM
    {
        IDLE,               //check for player
        PATROL,             //"melee": roam spawn point
        MOVE,               //found target, moving to target
        ATTACK,             //target in range, attack
        VANTAGE,            //"ranged": keep target in range, go to higher point, 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
