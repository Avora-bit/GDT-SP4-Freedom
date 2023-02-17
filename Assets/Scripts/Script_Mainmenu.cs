using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Script_Mainmenu : MonoBehaviour
{
    public Animator anim;
    public Image black;
    public TMP_InputField nameinput;
    public string name = "nameless";
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
        name = nameinput.text;
        StartCoroutine(Fading("Scene_Battle"));
       // Debug.LogError("Loggin");
    }

    IEnumerator Fading(string sceneName)
    {
        anim.SetBool("fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(sceneName);
    }
}
