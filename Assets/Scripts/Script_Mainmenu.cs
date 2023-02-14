using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_Mainmenu : MonoBehaviour
{
    public Animator anim;
    public Image black;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GuestLogin()
    {
        StartCoroutine(Fading());
       // Debug.LogError("Loggin");
    }
    IEnumerator Fading()
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("Scene_Battle");
    }
}
