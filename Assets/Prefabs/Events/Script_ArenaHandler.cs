using UnityEngine;

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

    private float time_Offset;

    //private int countNPC;                       //if 0, then all NPC dead, level ends
    // Start is called before the first frame update
    private void Awake()
    {
        TimeInstance = GetComponent<Script_Time>();
        TeleportStart = Teleport_TriggerStart.GetComponent<Script_Teleport>();
        TeleportEnd = Teleport_TriggerEnd.GetComponent<Script_Teleport>();
        arenaTime = numEnemyPerWave.Length * waveTimer + 1;
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
        
        if (TimeInstance.seconds == 0 && time_Offset <= 0)
        {
            time_Offset = 1f;
            int waveCount = numEnemyPerWave.Length - TimeInstance.minutes;          //inverting time into wave count
            for (int i = 0; i < numEnemyPerWave[waveCount]; i++)
            {
                //spawn enemy on wall
                GameObject NPCclone = Instantiate(prefab_NPC, gameObject.transform);
                NPCclone.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                NPCclone.gameObject.GetComponent<Script_baseAI>().enabled = true;
                NPCclone.gameObject.GetComponent<Script_baseFSM>().enabled = true;
                NPCclone.transform.parent = null;
                int gateDirection = Random.Range(0,3);
                int randXOffset = 0, randZOffset = 0;
                if (gateDirection == 0) randXOffset = 55;
                else if (gateDirection == 1) randXOffset = -55;
                else if (gateDirection == 2) randZOffset = 55;
                else  if (gateDirection == 3) randZOffset = -55;
                NPCclone.transform.SetPositionAndRotation(new Vector3(gameObject.transform.position.x + randXOffset, 16.0f, gameObject.transform.position.z + randZOffset), Quaternion.identity);
            }
            //last wave and boss is not spawned
            if ((waveCount == numEnemyPerWave.Length) && !spawnedBoss)
            {
                spawnedBoss = true;
                Debug.Log("spawning Boss");

                //instantiate boss at pos
                bossPtr = Instantiate(prefab_Boss, gameObject.transform);
            }
            
        }
    }

    public void SpawnEnemies()
    {
        //instantiate a lot of enemies on the stands
    }
}
