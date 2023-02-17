using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Throwing : MonoBehaviour
{
    public float throwStrength = 50f;
    private LineRenderer lineRenderer;
    private const int LinePoints = 20;
    private const float TimeBetweenPoints = 0.1f;
    private const float projectileMass = 100f;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DrawTrajectoryProjection(Vector3 location , Vector3 direction)
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = Mathf.CeilToInt(LinePoints / TimeBetweenPoints) + 1;
        Vector3 startPosition = location;
        Vector3 startVelocity = throwStrength * direction / projectileMass;
        int i = 0;
        lineRenderer.SetPosition(i, startPosition);
        for (float time = 0; time < LinePoints; time += TimeBetweenPoints)
        {
            i++;
            Vector3 point = startPosition + time * startVelocity;
            point.y = startPosition.y + startVelocity.y * time + (Physics.gravity.y / 2f * time * time);
            lineRenderer.SetPosition(i, point);
        }
    }
    public void StopTrajectoryDraw()
    {
        lineRenderer.enabled = false;
    }
}
