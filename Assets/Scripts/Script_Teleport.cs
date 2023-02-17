using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Teleport : MonoBehaviour
{
    public GameObject player;
    public Vector3 HubTeleportPos = new Vector3(-10,(float)1.5,0);
    public Vector3[] ArenaVectors; //Vectors: 0 - Default 1 - Desert 2 - Forest 3 - Volcanic


    public FirstPersonController fpc;

    private float timer;
    private int countdown;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer = 1.2f;
            countdown = 1;
            fpc.tping = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        timer = Mathf.Clamp(timer -= countdown*Time.deltaTime, 0, 1);
        if (timer <= 0)
        {
            countdown = 0;
            Debug.Log("Player Entered TP area");
            player.transform.position = HubTeleportPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
