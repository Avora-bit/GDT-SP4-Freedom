using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Script_GlobalTime : MonoBehaviour
{
    public float timeRemaining = 300;        //in seconds
    public bool timeActive = false;
    private float minutes;
    private float seconds;

    public TextMeshPro[] timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timeActive = false;
            }
            minutes = Mathf.FloorToInt(timeRemaining / 60);
            seconds = Mathf.FloorToInt(timeRemaining % 60);
        }
        DisplayTime(timeRemaining);
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        for (int i = 0; i < timeText.Length; i++) 
        {
            timeText[i].text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
