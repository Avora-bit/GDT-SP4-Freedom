using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Script_TriggerSpikes : MonoBehaviour
{
    public int iDamage = 10;
    public float fCooldown = 3f;
    private float fCurrentCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
    private void OnTriggerExit(Collider other)
    {

    }
    private void OnTriggerStay(Collider other)
    {
        //if (other.GetComponent<>() != null && fCurrentCooldown <= 0)
        //{
        //    //other.hp -= iDamage;
        //    Debug.Log("Spiked");
        //    //Debug.Log("player hp: " + other.hp);
        //    fCurrentCooldown = fCooldown;
        //}
    }
}
