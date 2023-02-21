using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_Endscene_get : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshPro texttest;
    public int graveID = 0;
    public string singlegrave;
    public string[] gravearray;
    private Vector3 pos;
    private Quaternion rotation;
    [SerializeField]
    GameObject grave;

    void Start()
    {
        pos.y = -6f;
        rotation.x = 0; rotation.y = 0; rotation.z = 0;
        int playcount = PlayerPrefs.GetInt("playamount");
        int totaldmg = PlayerPrefs.GetInt("dmgtaken");
        gravearray = new string[playcount];

       // texttest.text = "adventure #" + playcount.ToString() + "\ndamage taken: " + totaldmg.ToString();

        for (int i = 0; i < playcount; i++)
        {
            graveID = i;
            pos.x = 1.2f * (i % 4);
            pos.z = 3 * (i / 4);

            Instantiate(grave, pos, rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
