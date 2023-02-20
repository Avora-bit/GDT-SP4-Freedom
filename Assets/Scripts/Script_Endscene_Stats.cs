using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Endscene_Stats : MonoBehaviour
{
    private bool generated = false;
    public string[] statsarray;
    public string finalstr;
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
        statsarray = new string[4];
        int playcount = PlayerPrefs.GetInt("playamount");
        string ID = PlayerPrefs.GetInt("playamount").ToString();
        string name = PlayerPrefs.GetString("username");
        string location = PlayerPrefs.GetString("location");
        string causeOfDeath = PlayerPrefs.GetString("cause");
        statsarray[0] = ID; statsarray[1] = name; statsarray[2] = location; statsarray[3] = causeOfDeath;
        finalstr = '#' + statsarray[0] + "\n\n" + statsarray[1] + "\n\nCause of death:\n" + statsarray[2] + "\n\nCause of death:\n" + statsarray[3];

        PlayerPrefs.SetString("deathArray" + playcount, finalstr);


        PlayerPrefs.SetInt("dmgtaken", fpc.health.totaldmg);

        PlayerPrefs.SetInt("playamount", playcount + 1);


        PlayerPrefs.Save();
    }

}
