using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scirpt_UIBars : MonoBehaviour
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
        max = fpc.sprintDuration;
        
    }

    // Update is called once per frame
    void Update()
    {
        content = fpc.sprintRemaining;
        bar.transform.localScale = new Vector3(content / max, 1f, 1f);
    }
}
