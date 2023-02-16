using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Teleport : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered TP area");
            player.transform.position = new Vector3(-10, (float)1.5,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
