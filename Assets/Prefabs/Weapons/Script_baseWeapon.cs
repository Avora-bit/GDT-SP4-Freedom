using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_baseWeapon : MonoBehaviour
{
    //stats
    public int iDamage;
    public float fAttackSpeed;
    public Animator anim;
    public GameObject weapon;

    public int costStamina;

    //flags
    private float timeBetweenAttack;
    private float fcooldown;
    private bool canAttack;
    public bool isThrown = false;

    private float projectile_lifetime = 20f;

    private float dmgMultiplier = 2f;
    private float dmgVelocity;

    public GameObject projectile;
    

    void Start()
    {
        timeBetweenAttack = 1 / fAttackSpeed;
    }

    private void Update()
    {
        if (!canAttack) fcooldown -= Time.deltaTime;
        if (fcooldown <= 0f) canAttack = true;
        if (isThrown)
        {
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<MeshCollider>().enabled = true;
            gameObject.GetComponent<MeshCollider>().isTrigger = true;
            if (gameObject.GetComponent<Animator>() != null)
            {
                gameObject.GetComponent<Animator>().enabled = false;
            }

            projectile_lifetime -= Time.deltaTime;
            if (projectile_lifetime <= 0f)
            {
                Destroy(gameObject);
            }
            transform.rotation = Quaternion.LookRotation(gameObject.GetComponent<Rigidbody>().velocity);

            //damage multiplier for velocity
            //theoritical max velocity is 100, 100 mass with 10,000 force
            //min velocity is 10, 100 mas with 1000 force
            dmgVelocity = iDamage * (100 / gameObject.GetComponent<Rigidbody>().velocity.magnitude) * dmgMultiplier;
        }
    }

    private void PlayAnimation()
    {
        GetComponent<MeshCollider>().enabled = true;
        GetComponent<MeshCollider>().isTrigger = true;
        anim.speed = 1 / timeBetweenAttack;
        anim.SetTrigger("Attack");
    }

    public bool Attack()
    {
        if (canAttack)
        {
            PlayAnimation();
            fcooldown = timeBetweenAttack;
            canAttack = false;
            //Debug.LogWarning("parent: " + gameObject.transform.parent.name);
            return true;
        }
        else
        {
            //null
            Debug.Log("weapon cooldown");
            return false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!gameObject.transform.parent.name.Contains("NPC_Enemy"))
        {
            if (other.gameObject.name.Contains("NPC_Enemy") || other.gameObject.name.Contains("training_dummy"))
            {
                //Debug.LogWarning("Parent is NOT enemy");
                if (!isThrown)
                {
                    other.GetComponent<Script_baseHealth>().TakeDamage(iDamage);
                    if (other.GetComponent<Script_baseHealth>().InvincTimer <= 0.0f)
                    {
                        other.GetComponent<Script_baseHealth>().InvincTimer = timeBetweenAttack;
                    }
                }
                else
                {
                    other.GetComponent<Script_baseHealth>().TakeDamage((int)dmgVelocity);
                    Destroy(gameObject);
                }
            }
        }
        else
        {
            if (other.gameObject.name == "FirstPersonController")
            {
                Debug.LogWarning("Weapon from Enemy Hits Player");
                other.GetComponent<Script_baseHealth>().TakeDamage(iDamage/2,gameObject);
                if (other.GetComponent<Script_baseHealth>().InvincTimer <= 0.0f)
                {
                    other.GetComponent<Script_baseHealth>().InvincTimer = timeBetweenAttack;
                }
            }
        }
        if (isThrown && other.gameObject.tag == "Untagged")         //collision with environment
        {
            Destroy(gameObject);
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("NPC_Enemy") || other.gameObject.name.Contains("training_dummy"))
        {
            Debug.Log("Weapon left Enemy Hitbox");
        }
        if (!gameObject.transform.parent.name.Contains("NPC_Enemy") && other.gameObject.name == "FirstPersonController")
        {
            Debug.LogWarning("Enemy Weapon Left Player Hitbox");
        }
    }

    public bool Throw(Camera rayVector)
    {
        return false;
    }

    public int getStaminaCost()
    {
        return costStamina;
    }

    public void StopEvent(string s)
    {
        Debug.Log(s + " anim.length: " + anim.GetCurrentAnimatorStateInfo(0).length);
        anim.ResetTrigger("Attack");
    }
    public void HasStarted()
    {
        anim.ResetTrigger("Return");
        Debug.Log("Animation has started");
        anim.ResetTrigger("Attack");
    }

    public void IsInMiddle()
    {
        Debug.Log("Animation is in the middle");
    }

    public void Ended()
    {
        gameObject.GetComponent<MeshCollider>().isTrigger = false;
        gameObject.GetComponent<MeshCollider>().enabled = false;
        Debug.Log("Animation has ended");
        anim.SetTrigger("Return");
    }
}
