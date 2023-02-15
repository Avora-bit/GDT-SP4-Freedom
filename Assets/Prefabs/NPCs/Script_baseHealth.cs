using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_baseHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int selfHealth;
    private float timer = 0.5f;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        selfHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (selfHealth <= 0)
        {
            anim.SetBool("death", true);
           // Destroy(gameObject);        //death
        }
        if (anim.GetBool("hit") == true){
            timer -= 1 * Time.deltaTime;
        }
        if (timer <= 0)
        {
            anim.SetBool("hit", false);
            timer = 0.5f;
        }
        
    }

    public void TakeDamage(int _damage)
    {
        selfHealth -= _damage;
        anim.SetBool("hit", true);
        
    }

    public int getHealth()
    {
        return selfHealth;
    }

}
