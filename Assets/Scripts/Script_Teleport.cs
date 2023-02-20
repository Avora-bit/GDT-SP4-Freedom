using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Teleport : MonoBehaviour
{
    public FirstPersonController fpc;
    public Vector3 TeleportPos = new Vector3(0,0,0);

    private float timer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer = 2f;
            fpc.tping = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        timer = Mathf.Clamp(timer -= Time.deltaTime, 0, 1);
        if (timer <= 0)
        {
            fpc.transform.position = TeleportPos;
            //arena reference start
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startArena()
    {

    }
}
