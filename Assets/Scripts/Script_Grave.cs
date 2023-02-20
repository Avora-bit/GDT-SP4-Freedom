using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_Grave : MonoBehaviour
{
    GameObject gravestone;
    public int ID;
    TextMeshPro Gravetext;
    [SerializeField]
    Script_Endscene_get array;
    Script_Endscene_get db;
    // Start is called before the first frame update
    void Start()
    {
        db = GetComponent<Script_Endscene_get>();
        Gravetext = GetComponent<TextMeshPro>();
        ID = db.graveID;
        string final = PlayerPrefs.GetString("deathArray" + ID);
        Gravetext.text = final;
        Debug.Log(ID);
        Debug.Log(final);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
