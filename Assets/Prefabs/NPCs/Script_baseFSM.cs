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
    public int iStunCounter = 3; // time to get stunned
    //after 1 min ends, stop chase and wait for other enemies to spawn and reset self FSM

    private NavMeshAgent navMeshAgent;
    public Transform TargetPos;
    public bool IsMelee; // boolean to check whether the enemy is a melee type
    public bool IsRanged; // boolean to check whether the enemy is a ranged type
    public bool OnVantage; // boolean to check whether the enemy is on the vantage point
    public bool IsStunned; // booleN to check whether the enemy is stunned or not
    public GameObject ParentArcherTower;



    enum FSM
    {
        INACTIVE,
        IDLE = 0,           //check for player
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
        //navMeshAgent.destination = TargetPos.position;

        if (baseHealth.getHealth() <= 0)
        {
            currentFSM = FSM.DEATH;
        }

        switch (currentFSM){
            case FSM.IDLE:
                {
                    break;
                }
            case FSM.PATROL:
                {
                    if (IsMelee)
                    {

                    }
                    break;
                }
            case FSM.MOVE:
                {
                    break;
                }
            case FSM.ATTACK:
                {
                    if (IsMelee)
                    {

                    }

                    else if (IsRanged)
                    {

                    }
                    break;
                }
            case FSM.VANTAGE:
                {
                    if (baseHealth.getHealth() != 100 && IsRanged) // if enemy is an archer and isn't max health 
                    {
                        // get out of vantage point to flank/attack player on ground
                        //after getting out of vantage point (dropping to ground), enemy goes to attack
                        currentFSM = FSM.ATTACK;
                    }
                    else
                    {
                        // stay at vantage point and attack from range
                    }
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
