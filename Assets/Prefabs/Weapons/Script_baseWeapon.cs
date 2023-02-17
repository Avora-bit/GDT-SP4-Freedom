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

    //flags
    private float timeBetweenAttack;
    private float fcooldown;
    private bool canAttack;

    void Start()
    {
        timeBetweenAttack = 1 / fAttackSpeed;
    }

    private void Update()
    {
        if (!canAttack) fcooldown -= Time.deltaTime;
        if (fcooldown <= 0f) canAttack = true;
    }

    private void PlayAttackAnimation()
    {
        anim.speed = 1 / timeBetweenAttack;
        anim.SetTrigger("Attack");
    }

    public void Attack(Camera rayVector)
    {
        if (canAttack)
        {
            PlayAttackAnimation();
            Debug.Log("Damage: " + iDamage + " Attack Speed: " + fAttackSpeed + " Range: " + fRange + " TimeBetweenAttack: " + timeBetweenAttack);
            Vector3 origin = new Vector3(rayVector.transform.position.x, rayVector.transform.position.y, rayVector.transform.position.z);
            Vector3 direction = rayVector.transform.forward;

            if (Physics.Raycast(origin, direction, out RaycastHit hit, fRange))
            {
                Debug.DrawRay(origin, direction * fRange, Color.yellow);
                Debug.Log("GameObject hit: " + hit.collider.name);
                //deal damage
                if (hit.collider.GetComponent<Script_baseHealth>() != null)
                {
                    hit.collider.GetComponent<Script_baseHealth>().TakeDamage(iDamage);
                    Debug.Log("Hit");
                }
            }
            fcooldown = timeBetweenAttack; 
        }
        else
        {
            //null
            Debug.Log("weapon cooldown");
        }
    }

    public void StopEvent(string s)
    {
        Debug.Log(s + " anim.length: " + anim.GetCurrentAnimatorStateInfo(0).length);
        anim.ResetTrigger("Trigger");
    }
}
