using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Script_Endscene_get : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshPro texttest;
    public int graveamount = 0;
    public int currentgrave;
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
        graveamount = PlayerPrefs.GetInt("playamount");
        for (int i = 0; i < graveamount; i++)
        {
            pos.x = 1.2f * (i % 4);
            //z = i / 4 + 1;
            pos.z = 3 * (i / 4);
            currentgrave = i;
            GameObject newgrave = Instantiate(grave, pos, rotation, gameObject.transform);
            newgrave.GetComponent<Script_Grave>().ID = i+1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
