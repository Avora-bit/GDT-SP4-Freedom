using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Endscene_Stats : MonoBehaviour
{
    private bool generated = false;
    [SerializeField]
    FirstPersonController fpc;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("dmgtaken", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(fpc.health.selfHealth <= 0 && generated == false)
        {
            generateStats();
            generated = true;
        }
    }
    void generateStats()
    {
        PlayerPrefs.SetInt("dmgtaken", fpc.health.totaldmg);
        int playcount = PlayerPrefs.GetInt("playamount");
        PlayerPrefs.SetInt("playamount", playcount += 1);
        PlayerPrefs.Save();
    }

}
