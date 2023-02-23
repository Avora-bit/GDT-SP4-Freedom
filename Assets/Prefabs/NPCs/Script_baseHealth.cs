using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class Script_baseHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int selfHealth;
    public int totaldmg;
    public bool IsPlayer = false;
    public bool IsDummy = false;

    public float InvincTimer = 1.0f;

    public GameObject damageTextPrefab;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        selfHealth = maxHealth;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        selfHealth = Mathf.Clamp(selfHealth, 0, 100);

        InvincTimer = Mathf.Clamp(InvincTimer -= Time.deltaTime, 0, 10);
    }

    public void TakeDamage(int _damage)
    {
        if (InvincTimer <= 0)
        {
            string text = _damage + "!";

            selfHealth -= _damage;
            if (IsPlayer)
            {
                totaldmg += _damage;
            }
            else FloatingText(text, Color.red);
        }
        if (IsDummy)
        {
            source.Play();
        }

    }

    public void Healing(int _heal)
    {
        string text = ">" + _heal + "<"; 
        selfHealth = Mathf.Clamp(selfHealth += _heal, 0, maxHealth);
        if (!IsPlayer) FloatingText(text, Color.green);
    }

    public int getHealth()
    {
        return selfHealth;
    }

    //if game object is dummy or npc, render damage text
    public void FloatingText(string _text, Color _color)
    {
        GameObject DamageTextInstance = Instantiate(damageTextPrefab, gameObject.transform);
        DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().transform.rotation = Camera.main.transform.rotation;
        DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(_text);
        DamageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().color = _color;
        if (selfHealth <= 0)
        {
            DamageTextInstance.transform.parent = null;
        }
    }
}
