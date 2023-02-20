using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ArenaHandler : MonoBehaviour
{
    Script_Time TimeInstance;

    //boss instance
    bool spawnBoss = false;

    // Start is called before the first frame update
    void Start()
    {
        TimeInstance = GetComponent<Script_Time>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeInstance.seconds == 0)
        {
            if (TimeInstance.minutes == 5)
            {

            }
            else if (TimeInstance.minutes == 4)
            {

            }
            else if(TimeInstance.minutes == 3)
            {

            }
            else if(TimeInstance.minutes == 2)
            {

            }
            else if(TimeInstance.minutes == 1)
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
