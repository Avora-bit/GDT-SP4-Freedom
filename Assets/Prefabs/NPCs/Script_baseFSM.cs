using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_baseFSM : MonoBehaviour
{
    FSM currentFSM = 0;
    int iFSMCounter = 0;
    public const float iMaxFSMCounter = 60f;       //in seconds
    //after 1 min ends, stop chase and wait for other enemies to spawn and reset self FSM

    enum FSM
    {
        INACTIVE = 0,
        IDLE,               //check for player
        PATROL,             //"melee": roam spawn point
        MOVE,               //found target, moving to target
        ATTACK,             //target in range, attack
        VANTAGE,            //"ranged": keep target in range, go to higher point, 
        DEATH
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentFSM){
            case FSM.INACTIVE:
                {
                    break;
                }
            case FSM.IDLE:
                {
                    break;
                }
            case FSM.PATROL:
                {
                    break;
                }
            case FSM.MOVE:
                {
                    break;
                }
            case FSM.ATTACK:
                {
                    break;
                }
            case FSM.VANTAGE:
                {
                    break;
                }
            case FSM.DEATH:
                {
                    break;
                }
            default:
                {
                    break;
                }
        };


    }

    public void resetFSM()
    {
        currentFSM = FSM.INACTIVE;
        iFSMCounter = 0;
    }
}
