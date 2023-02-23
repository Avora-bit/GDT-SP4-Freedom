using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Script_baseAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;
    public Transform garbage;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public bool isStrafing;

    Script_baseFSM FSMScript;

    private void Awake()
    {
        player = GameObject.Find("FirstPersonController").transform;
        garbage = GameObject.Find("Garbage Container").transform;
        agent = GetComponent<NavMeshAgent>();
        FSMScript = GetComponent<Script_baseFSM>();
        
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && FSMScript.OnVantage == false) Patroling();
        if (playerInSightRange && !playerInAttackRange && FSMScript.OnVantage == false) ChasePlayer();
        if (playerInAttackRange && playerInSightRange && FSMScript.OnVantage == false) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    // For Archers if they are on vantage point, their isStrafing variable is off and they stand on the vantage point and shoot, else when they take damage they move off the tower
    // and strafe assault the player

    // For melee enemies they will have different states including rushing towards the player, encircling the player, flanking, tactical retreat

    private void AttackPlayer()
    {
        if (FSMScript.IsMelee)
        {
            if (FSMScript.FSMState == Script_baseFSM.FSM.ATTACK)
            {

            }
            // Melee Code Here


        }

        else if (FSMScript.IsRanged)
        {
            transform.LookAt(player);

            if (!alreadyAttacked && FSMScript.FSMState == Script_baseFSM.FSM.ATTACK)
            {
                // Ranged Code Here
                // Archer is able to strafe and is not on an archer tower
                if (isStrafing && FSMScript.OnVantage == false)
                {
                    if (!walkPointSet) SearchWalkPoint();

                    if (walkPointSet)
                        agent.SetDestination(walkPoint);

                    Vector3 distanceToWalkPoint = transform.position - walkPoint;

                    //Walkpoint reached
                    if (distanceToWalkPoint.magnitude < 5f)
                        walkPointSet = false;
                }
                else
                {
                    // Archer stands in place
                    agent.SetDestination(transform.position);
                }
                ///Attack code here
                Rigidbody rb = Instantiate(projectile, transform.position + (transform.forward * 2) + (transform.up * 0.3f), Quaternion.identity,garbage).GetComponent<Rigidbody>();
                //Debug.Log(transform.position);
                rb.AddForce(transform.forward * 32f, ForceMode.Impulse); // forward force of projectile
                rb.AddForce(transform.up * 8f, ForceMode.Impulse); // upward force of projectile
                ///End of attack code

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}