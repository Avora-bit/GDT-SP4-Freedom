using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Script_baseFSM : MonoBehaviour
{
    Script_baseHealth baseHealth;

    FSM currentFSM = 0;
    int iFSMCounter = 0;
    public const float iMaxFSMCounter = 60f;       //in seconds
    //after 1 min ends, stop chase and wait for other enemies to spawn and reset self FSM

    private NavMeshAgent navMeshAgent;
    public Transform TargetPos;

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
        baseHealth = GetComponent<Script_baseHealth>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = TargetPos.position;

        if (baseHealth.getHealth() <= 0)
        {
            currentFSM = FSM.DEATH;
        }

        switch (currentFSM){
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
                    //drop weapon
                    GameObject Clone = Instantiate(transform.GetChild(0).gameObject, transform.position, Quaternion.identity);
                    Clone.name = transform.GetChild(0).gameObject.name;
                    Clone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    Clone.GetComponent<BoxCollider>().enabled = true;

                    //destroy self
                    Destroy(gameObject);
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
