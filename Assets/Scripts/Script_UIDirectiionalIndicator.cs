using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Script_UIDirectiionalIndicator : MonoBehaviour
{
    public GameObject target;
    private Color color;

    private float timeTotal = 1f;
    private float timeRemaining;

    private bool isTargetGate = true;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeTotal;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTargetGate)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                Destroy(gameObject);
            }
            //only fade if the target is not a gate
            gameObject.GetComponent<RawImage>().color = new Color(color.r, color.g, color.b, timeRemaining / timeTotal);
        }
        
        if (target != null)         //check if the target is active, if died then dont need to check
        {
            GameObject playerInstance = gameObject.transform.parent.parent.parent.gameObject;
            Vector3 playerForward = new Vector3(playerInstance.transform.forward.x, 0, playerInstance.transform.forward.z).normalized;
            Vector3 playerPos = playerInstance.transform.position;
            Vector3 targetPos = target.transform.position;
            Vector3 targetDir = playerPos - targetPos;
            Vector3 targetRot = new Vector3(targetDir.x, 0, targetDir.z).normalized;

            Vector3 playerRight = new Vector3(playerInstance.transform.right.x, 0, playerInstance.transform.right.z).normalized;
            float angleRot = Vector3.Angle(playerForward, targetRot) - 180;
            if (Vector3.Angle(playerRight, targetRot) < 90f)       //on right side
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -angleRot);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, angleRot);
            }

            Debug.Log(angleRot);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void setTime(float _time)
    {
        timeTotal = _time;
        timeRemaining = _time;
    }

    public void setTarget(GameObject _target)
    {
        target = _target;
    }

    public void setColor(Color _color)
    {
        color = _color;
    }

    public void setIsGate(bool _isGate)
    {
        isTargetGate = _isGate;
    }

    public bool getIsGate()
    {
        return isTargetGate;
    }
}
