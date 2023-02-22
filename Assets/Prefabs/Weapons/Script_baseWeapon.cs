using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_baseWeapon : MonoBehaviour
{
    //stats
    public int iDamage;
    public float fAttackSpeed;
    public float fRange;
    public Animator anim;
    public GameObject weapon;

    public int costStamina;

    //flags
    private float timeBetweenAttack;
    private float fcooldown;
    private bool canAttack;
    private bool isThrown = false;

    public GameObject projectile;

    void Start()
    {
        timeBetweenAttack = 1 / fAttackSpeed;
    }

    private void Update()
    {
        if (!canAttack) fcooldown -= Time.deltaTime;
        if (fcooldown <= 0f) canAttack = true;
    }

    private void PlayAnimation()
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        anim.speed = 1/timeBetweenAttack;
        anim.SetTrigger("Attack");
    }

    public bool Attack(Camera rayVector)
    {
        if (canAttack)
        {
            PlayAnimation();
            //Debug.Log("Damage: " + iDamage + " Attack Speed: " + fAttackSpeed + " Range: " + fRange + " TimeBetweenAttack: " + timeBetweenAttack);
            //Vector3 origin = new Vector3(rayVector.transform.position.x, rayVector.transform.position.y, rayVector.transform.position.z);
            //Vector3 direction = rayVector.transform.forward;

            //if (Physics.Raycast(origin, direction, out RaycastHit hit, fRange))
            //{
            //    Debug.DrawRay(origin, direction * fRange, Color.yellow);
            //    Debug.Log("GameObject hit: " + hit.collider.name);
            //    //deal damage
            //    if (hit.collider.GetComponent<Script_baseHealth>() != null)
            //    {
            //        hit.collider.GetComponent<Script_baseHealth>().TakeDamage(iDamage);
            //        Debug.Log("Hit");
            //    }
            //}
            fcooldown = timeBetweenAttack;
            canAttack = false;
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
        if (other.gameObject.name.Contains("NPC_Enemy") || other.gameObject.name.Contains("training_dummy"))
        {
            other.GetComponent<Script_baseHealth>().TakeDamage(iDamage);
            if (other.GetComponent<Script_baseHealth>().InvincTimer <= 0.0f)
            {
                other.GetComponent<Script_baseHealth>().InvincTimer = timeBetweenAttack;
            }
            Debug.Log("Weapon Hit Enemy Hitbox");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("NPC_Enemy") || other.gameObject.name.Contains("training_dummy"))
        {
            Debug.Log("Weapon left Enemy Hitbox");
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
        gameObject.GetComponent<BoxCollider>().isTrigger = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("Animation has ended");
        anim.SetTrigger("Return");
    }
}
