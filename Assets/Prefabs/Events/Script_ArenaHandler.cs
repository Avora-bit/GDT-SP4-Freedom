using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Script_ArenaHandler : MonoBehaviour
{
    Script_Time TimeInstance;

    public GameObject Teleport_TriggerStart, Teleport_TriggerEnd;

    private Script_Teleport TeleportStart, TeleportEnd;

    //if start is triggered, handler is active and timer is set
    //when player clears the level, activate the end
    //the end is then referenced by the next arena to start the arena

    public float waveTimer = 60f;
    private float arenaTime;
    //boss instance
    private bool spawnedBoss = false;           //ensure 1 boss is spawned

    public GameObject prefab_NPC;

    public int[] numEnemyPerWave;

    public GameObject prefab_Boss;
    private GameObject bossPtr = null;          //if dead, then level ends

    private float time_Offset = 0f;

    //private int countNPC;                       //if 0, then all NPC dead, level ends
    // Start is called before the first frame update
    private void Awake()
    {
        TimeInstance = GetComponent<Script_Time>();
        TeleportStart = Teleport_TriggerStart.GetComponent<Script_Teleport>();
        TeleportEnd = Teleport_TriggerEnd.GetComponent<Script_Teleport>();
        arenaTime = numEnemyPerWave.Length * waveTimer + 2;
    }

    // Update is called once per frame
    void Update()
    {
        //teleporting in and out of arena and boss checking
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
        }

        //npc spawning
        if (time_Offset > 0) time_Offset -= Time.deltaTime;
        else time_Offset = 0;

        if (TimeInstance.seconds == 1 && time_Offset <= 0)
        {
            time_Offset = 5f;
            int waveCount = numEnemyPerWave.Length - TimeInstance.minutes;          //inverting time into wave count
            //Debug.Log("Num Ene: " + numEnemyPerWave[waveCount]);

            //last wave and boss is not spawned
            if (numEnemyPerWave.Length == waveCount && bossPtr == null && !spawnedBoss)
            {
                spawnedBoss = true;

                bossPtr = Instantiate(prefab_Boss, gameObject.transform.position, Quaternion.identity);
                bossPtr.gameObject.GetComponent<Script_baseAI>().enabled = true;
                bossPtr.gameObject.GetComponent<Script_baseFSM>().enabled = true;
                bossPtr.GetComponent<NavMeshAgent>().Warp(new Vector3(gameObject.transform.position.x, 17f, gameObject.transform.position.z - 55));     //spawn boss at gate
            }
            Debug.Log("length of Number Per Wave: " + numEnemyPerWave.Length + " / Wave Count: " + waveCount + " / IsSpawnedBoss: " + spawnedBoss + " / bossPtr: " + bossPtr);
            if (!spawnedBoss)
            {
                for (int i = 0; i < numEnemyPerWave[waveCount]; i++)
                {
                    GameObject NPCclone = Instantiate(prefab_NPC, gameObject.transform.position, Quaternion.identity);
                    NPCclone.gameObject.GetComponent<Script_baseAI>().enabled = true;
                    NPCclone.gameObject.GetComponent<Script_baseFSM>().enabled = true;
                    int gateDirection = Random.Range(0, 3);
                    int randXOffset = 0, randZOffset = 0;
                    if (gateDirection == 0) randXOffset = 55;
                    else if (gateDirection == 1) randXOffset = -55;
                    else if (gateDirection == 2) randZOffset = 55;
                    else if (gateDirection == 3) randZOffset = -55;
                    NPCclone.GetComponent<NavMeshAgent>().Warp(new Vector3(gameObject.transform.position.x + randXOffset, 16f, gameObject.transform.position.z + randZOffset));
                }
            }
        }
    }

    public void SpawnEnemies()
    {
        //instantiate a lot of enemies on the stands
    }
}
