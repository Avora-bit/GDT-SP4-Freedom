using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_baseHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int selfHealth;

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
            Destroy(gameObject);        //death
        }
    }

    public void TakeDamage(int _damage)
    {
        selfHealth -= _damage;
    }

    public int getHealth()
    {
        return selfHealth;
    }
}
