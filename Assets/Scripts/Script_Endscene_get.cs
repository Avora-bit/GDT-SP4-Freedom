using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_Endscene_get : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshPro texttest;

    void Start()
    {
        int playcount = PlayerPrefs.GetInt("playamount");
        int totaldmg = PlayerPrefs.GetInt("dmgtaken");

        texttest.text = "adventure #" + playcount.ToString() + "\ndamage taken: " + totaldmg.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
