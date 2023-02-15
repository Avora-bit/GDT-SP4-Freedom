using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Script_baseHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int selfHealth;
    private float timer = 0.5f;
    public Animator anim;
    public Animator anim2;
    public Image red;
    public Image black;
    
    // Start is called before the first frame update
    void Start()
    {
        selfHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (selfHealth <= 0)
        {
            StartCoroutine(die());

            // Destroy(gameObject);        //death
        }
        if (anim.GetBool("hit") == true)
        {
            timer -= 1 * Time.deltaTime;
        }
        if (timer <= 0)
        {
            anim.SetBool("hit", false);
            timer = 0.5f;
        }

    }

    public void TakeDamage(int _damage)
    {
        selfHealth -= _damage;
        anim.SetBool("hit", true);

    }

    public int getHealth()
    {
        return selfHealth;
    }
    IEnumerator die()
    {
        anim.SetBool("death", true);
        yield return new WaitUntil(() => red.color.a == 1);
         StartCoroutine(change());
       // SceneManager.LoadScene("Scene_End");
    }
    IEnumerator change()
    {
        anim2.SetBool("fade", true);
        Debug.LogError("THE END?");
        yield return new WaitUntil(() => black.color.a == 1);
        Debug.LogError("THE END");
        SceneManager.LoadScene("Scene_End");
    }
}
