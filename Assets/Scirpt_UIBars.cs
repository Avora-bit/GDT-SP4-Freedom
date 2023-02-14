using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scirpt_UIBars : MonoBehaviour
{
    private const float max = 100.0f;
    public float content = max;
    private Image bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        bar.fillAmount = content / max;
    }
}
