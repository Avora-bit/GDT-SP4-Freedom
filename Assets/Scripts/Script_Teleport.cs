using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Teleport : MonoBehaviour
{
    public GameObject player;
    public Vector3 HubTeleportPos = new Vector3(-10,(float)1.5,0);
    public Vector3[] ArenaVectors;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Entered TP area");
            player.transform.position = HubTeleportPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
