using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Script_CreateDirectionalIndicator : MonoBehaviour
{
    public GameObject arrowPrefab;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createDamageIndicator(GameObject _target, bool _isObjective)
    {
        GameObject newArrow = Instantiate(arrowPrefab, gameObject.transform);
        newArrow.transform.parent = gameObject.transform;
        newArrow.GetComponent<Script_UIDirectiionalIndicator>().setTarget(_target, _isObjective);
    }

    public void deleteAll()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
