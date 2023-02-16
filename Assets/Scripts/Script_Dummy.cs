using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Dummy : MonoBehaviour
{
    public float timer;
    public float deadtime;
    public float deadneutraltime;
    public float revivetime;

    public bool dead = false;
    public bool deadneutral = false;
    public bool revive = false;
    public Animator anim;
    private bool toggle = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = Mathf.Clamp(timer - Time.deltaTime, 0, 1);
        if (deadneutral)
        {
            if (deadneutraltime > 0)
            {
                deadneutraltime = Mathf.Clamp(deadneutraltime - Time.deltaTime, 0, 5);
            }
            else
            {
                deadneutral = false;
                anim.SetBool("dead", false);
                anim.SetBool("deadneutral", true);
                deadtime = 2;
                dead = true;
            }
        }
        if (dead)
        {          
            if (deadtime > 0)
            {
                deadtime = Mathf.Clamp(deadtime - Time.deltaTime, 0, 5);
            }
            else
            {
                dead = false;
                anim.SetBool("deadneutral", false);
                anim.SetBool("revive", true);
                revivetime = 0.9f;
                revive = true;
            }
        }
        if (revive)
        {
            if (revivetime > 0)
            {
                revivetime = Mathf.Clamp(revivetime - Time.deltaTime, 0, 5);
            }
            else
            {
                revive = false;
                anim.SetBool("revive", false);
                anim.SetBool("backtoneutral", true);
            }
        }



        if (Input.GetKey(KeyCode.Alpha1) && toggle == false)
        {
            toggle = true;
            anim.SetBool("hit", true);
            timer = 0.1f;
           // Debug.Log(anim.GetBool("hit"));

        }
        if (Input.GetKey(KeyCode.Alpha2) && toggle == false)
        {
            toggle = true;
            anim.SetBool("backtoneutral" , false);
            anim.SetBool("dead", true);
            deadneutraltime = 1;
            deadneutral = true;
        }
        
        if (Input.GetKey(KeyCode.Alpha3) && toggle == false)
        {
            toggle = true;
            anim.SetBool("dead", false);
            anim.SetBool("deadneutral", true);
            deadtime = 2;
            dead = true;
        }
        if (Input.GetKey(KeyCode.Alpha4) && toggle == false)
        {
            toggle = true;
            anim.SetBool("deadneutral", false);
            anim.SetBool("revive", true);
        }
        if (Input.GetKey(KeyCode.Alpha5) && toggle == false)
        {
            toggle = true;
            anim.SetBool("revive", false);
            anim.SetBool("backtoneutral", true);
     
        }

        if (toggle == true && !Input.GetKey(KeyCode.Alpha1))
        {
            toggle = false;
        }
        if (toggle == true && !Input.GetKey(KeyCode.Alpha2))
        {
            toggle = false;
        }
        if (toggle == true && !Input.GetKey(KeyCode.Alpha3))
        {
            toggle = false;
        }
        if (toggle == true && !Input.GetKey(KeyCode.Alpha4))
        {
            toggle = false;
        }
        if (toggle == true && !Input.GetKey(KeyCode.Alpha5))
        {
            toggle = false;
        }
        if (timer <= 0)
        {
            anim.SetBool("hit", false);
        }
    }
}
