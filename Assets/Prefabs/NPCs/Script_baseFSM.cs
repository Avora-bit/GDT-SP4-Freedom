using System;
using UnityEngine;
using UnityEngine.AI;

public class Script_baseFSM : MonoBehaviour
{
    Script_baseHealth baseHealth;

    public FSM currentFSM = 0;
    int iFSMCounter = 0;
    public const float iMaxFSMCounter = 60f;       //in seconds
    public int iStunCounter = 3; // time to get stunned
    //after 1 min ends, stop chase and wait for other enemies to spawn and reset self FSM
    Script_baseAI ScriptAI;

    private NavMeshAgent navMeshAgent;
    public Transform TargetPos;
    public bool IsMelee; // boolean to check whether the enemy is a melee type
    public bool IsRanged; // boolean to check whether the enemy is a ranged type
    public bool OnVantage; // boolean to check whether the enemy is on the vantage point
    public bool IsStunned; // booleN to check whether the enemy is stunned or not
    public GameObject ParentArcherTower;
    public Transform garbage;

    public int dropRate = 25;

    public enum FSM
    {
        INACTIVE,
        IDLE = 0,           //check for player
        PATROL,             //"melee": roam spawn point
        MOVE,               //found target, moving to target
        ATTACK,             //target in range, attack
        RETREAT,            //fall back distance, regroup and reorganise
        ENCIRCLE,           //player found, going to surround player
        VANTAGE,            //"ranged": keep target in range, go to higher point, 
        DEATH
    }

    // Start is called before the first frame update
    void Start()
    {
        baseHealth = GetComponent<Script_baseHealth>();
        garbage = GameObject.Find("Garbage Container").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //navMeshAgent.destination = TargetPos.position;
        //Debug.Log(FSMState);

        if (baseHealth.getHealth() <= 0)
        {
            currentFSM = FSM.DEATH;
        }
        else
        {
            currentFSM = FSM.ATTACK;
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
                        //ScriptAI.isStrafing = true;
                    }
                    break;
                }
            case FSM.RETREAT:
                {
                    break;
                }
            case FSM.ENCIRCLE:
                {
                    break;
                }
            case FSM.VANTAGE:
                {
                    if (baseHealth.getHealth() != 100 && IsRanged) // if enemy is an archer and isn't max health 
                    {
                        // get out of vantage point to flank/attack player on ground
                        //after getting out of vantage point (dropping to ground), enemy goes to attack
                        OnVantage = false;
                    }
                    else if (baseHealth.getHealth() == 100)
                    {
                        // stay at vantage point and attack from range
                        OnVantage = true;
                    }
                    break;
                }
            case FSM.DEATH:
                {
                    //drop weapon
                    GameObject Clone = Instantiate(transform.GetChild(0).gameObject, transform.position, Quaternion.identity,garbage);
                    Clone.name = transform.GetChild(0).gameObject.name;
                    Clone.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    Clone.GetComponent<MeshCollider>().enabled = true;

                    GameObject body1 = Instantiate(transform.GetChild(2).gameObject, transform.position, Quaternion.identity);
                    body1.GetComponent<Script_GIbs>().vanishing = true;
                    body1.name = transform.GetChild(2).gameObject.name;
                    body1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                    GameObject body2 = Instantiate(transform.GetChild(3).gameObject, transform.position, Quaternion.identity);
                    body2.GetComponent<Script_GIbs>().vanishing = true;
                    body2.name = transform.GetChild(3).gameObject.name;
                    body2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    GameObject body3 = Instantiate(transform.GetChild(4).gameObject, transform.position, Quaternion.identity);
                    body3.GetComponent<Script_GIbs>().vanishing = true;
                    body3.name = transform.GetChild(4).gameObject.name;
                    body3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                    if (UnityEngine.Random.Range(0, 100) <= dropRate)
                    {
                        //drop other
                        GameObject Other = Instantiate(transform.GetChild(1).gameObject, transform.position, Quaternion.identity,garbage);
                        Other.name = transform.GetChild(1).gameObject.name;
                        Other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    }

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
