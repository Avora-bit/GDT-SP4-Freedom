using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ArenaHandler : MonoBehaviour
{
    Script_Time TimeInstance;

    public GameObject Teleport_TriggerStart, Teleport_TriggerEnd;

    private Script_Teleport TeleportStart, TeleportEnd;

    public float timeRemaining = 300f;

    //if start is triggered, start the handler
    //when player clears the level, activate the end
    //the end is then referenced by the next arena to start the arena

    //boss instance
    bool spawnBoss = false;

    // Start is called before the first frame update
    private void Awake()
    {
        TimeInstance = GetComponent<Script_Time>();
        TeleportStart = Teleport_TriggerStart.GetComponent<Script_Teleport>();
        TeleportEnd = Teleport_TriggerEnd.GetComponent<Script_Teleport>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TeleportStart.teleported)
        {
            TimeInstance.setTime(timeRemaining);
            TimeInstance.ActivateTime(true);
        }

        if (!TimeInstance.getState())
        {
            TeleportEnd.gameObject.SetActive(true);
        }
        else
        {
            TeleportEnd.gameObject.SetActive(false);
        }



        if (TimeInstance.seconds == 0)
        {
            if (TimeInstance.minutes == 5)
            {

            }
            else if (TimeInstance.minutes == 4)
            {

            }
            else if (TimeInstance.minutes == 3)
            {

            }
            else if (TimeInstance.minutes == 2)
            {

            }
            else if (TimeInstance.minutes == 1)
            {

            }
            else
            {
                //minute = 0
                if (!spawnBoss)
                {
                    spawnBoss = true;
                    Debug.Log("spawning Boss");
                }
            }
        }
    }

    public void SpawnEnemies()
    {
        //instantiate a lot of enemies on the stands
    }
}
