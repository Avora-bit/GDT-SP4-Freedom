using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Script_baseHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int selfHealth;
    public int totaldmg;
    public bool IsPlayer = false;
    public bool IsDummy = false;
    
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
            selfHealth = 0;
            if (IsPlayer)
                Debug.Log("player die");
            else if (IsDummy)
                Debug.Log("dummy die");
        }
    }

    public void TakeDamage(int _damage)
    {
        selfHealth -= _damage;
        if (IsPlayer)
        {
            totaldmg += _damage;
        }
    }

    public void Healing(int _heal)
    {
        selfHealth = Mathf.Clamp(selfHealth += _heal, 0, maxHealth);
    }

    public int getHealth()
    {
        return selfHealth;
    }
}
