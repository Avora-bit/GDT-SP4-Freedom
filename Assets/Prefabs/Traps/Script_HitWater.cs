using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_HitWater : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "FirstPersonController")
        {
            Debug.Log("Player Touch Water " + other.gameObject.GetComponent<FirstPersonController>().walkSpeed);
            other.gameObject.GetComponent<FirstPersonController>().isInWater = true;
            other.gameObject.GetComponent<FirstPersonController>().walkSpeed = 2.5f;
        }
        else if (other.gameObject.name.Contains("NPC_Enemy"))
        {
            Debug.Log("Enemy Touch Water");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FirstPersonController")
        {
            Debug.Log("Player Left Water " + other.gameObject.GetComponent<FirstPersonController>().walkSpeed);
            other.gameObject.GetComponent<FirstPersonController>().isInWater = false;
            other.gameObject.GetComponent<FirstPersonController>().walkSpeed = 5.0f;
        }
        else if (other.gameObject.name.Contains("NPC_Enemy"))
        {
            Debug.Log("Enemy Left Water");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
