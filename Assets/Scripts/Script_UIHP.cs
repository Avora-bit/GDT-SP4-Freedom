using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_UIHP : MonoBehaviour
{

    public float content = 1f;
    private float max = 100.0f;
    private Image bar;
    [SerializeField]
    FirstPersonController fpc;


    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        max = fpc.max_hp;

    }

    // Update is called once per frame
    void Update()
    {
        content = fpc.hp;
        bar.transform.localScale = new Vector3(content / max, 1f, 1f);
    }
}
