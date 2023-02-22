using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Script_ArenaHandler : MonoBehaviour
{
    Script_Time TimeInstance;

    public GameObject Teleport_TriggerStart, Teleport_TriggerEnd;

    private Script_Teleport TeleportStart, TeleportEnd;

    public float arenaTime = 300f;          //total time for 1 arena
    private float timeRemaining;

    //if start is triggered, handler is active and timer is set
    //when player clears the level, activate the end
    //the end is then referenced by the next arena to start the arena

    //boss instance
    bool spawnedBoss = false;           //ensure 1 boss is spawned

    public GameObject prefab_NPC;

    public GameObject prefab_Boss;
    private GameObject bossPtr = null;          //if dead, then level ends

    private int countNPC;                       //if 0, then all NPC dead, level ends
    // Start is called before the first frame update
    private void Awake()
    {
        TimeInstance = GetComponent<Script_Time>();
        TeleportStart = Teleport_TriggerStart.GetComponent<Script_Teleport>();
        TeleportEnd = Teleport_TriggerEnd.GetComponent<Script_Teleport>();
        timeRemaining = arenaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (TeleportStart.teleported)               //entered arena
        {
            TimeInstance.setTime(arenaTime);
            spawnedBoss = false;
            TimeInstance.ActivateTime(true);
        }
        if (TeleportEnd.teleported)                 //left arena
        {
            TimeInstance.setTime(arenaTime);        //reset time
            spawnedBoss = false;
        }

        //if timer is done and boss is dead
        if (!TimeInstance.getState() && spawnedBoss && bossPtr != null)
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
                //minute = 0 and time is active
                if (TimeInstance.getState() && !spawnedBoss)
                {
                    spawnedBoss = true;
                    Debug.Log("spawning Boss");

                    //instantiate boss at pos
                    bossPtr = Instantiate(prefab_Boss, gameObject.transform);
                }
            }
        }
    }

    public void SpawnEnemies()
    {
        //instantiate a lot of enemies on the stands
    }
}
