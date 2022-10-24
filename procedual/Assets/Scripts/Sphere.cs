using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public int pointCount = 100;
    public float radius = 14;
    public Color startColor, endColor;
    public float pointSpeed = 1f;
    public float pointSize = 0.15f;
    List<AnimatedVector> animatedVectors = new List<AnimatedVector>();
    float goldenRatio = (1 + Mathf.Sqrt(0.5f)) / 2; // two quantities are in the golden ratio if their ratio is the same as the ratio of their sum to the larger of the two quantities

    void onValidate() //run in editor
    {
        pointCount = Mathf.Max(0, pointCount);
        Update();
    }

    private void Update()
    {
        //Remove Deleted Points
        if (animatedVectors.Count > pointCount) 
        {
            int dif = animatedVectors.Count - pointCount;
            animatedVectors.RemoveRange(pointCount, dif);
        }

        //Add and Update new points
        for (int i = 0; i < pointCount; i++) 
        {
            Vector3 targetPoint = GetPointAtIndex(i);

            if (i >= animatedVectors.Count)
            {
                animatedVectors.Add(new AnimatedVector(Origin(), targetPoint));
            }
            else
            {
                animatedVectors[i].target = targetPoint;
            }
            animatedVectors[i].Animate(pointSpeed);
        }
    }

    Vector3 GetPointAtIndex(int index) //fib math that determines the next sphere's position
    {
        float j = index + 0.5f;
        float phi = Mathf.Acos(1 - 2 * j / pointCount);
        float theta = 2 * Mathf.PI * j / goldenRatio;
        float x = Mathf.Cos(theta) * Mathf.Sin(phi);
        float y = Mathf.Sin(theta) * Mathf.Sin(phi);
        float z = Mathf.Cos(phi);

        Vector3 newPoint = new Vector3(x, y, z);
        return newPoint;
    }

    Vector3 Origin() //return the position of each sphere so it can be calculated when placing the next.
    {
        return transform.position;
    }

    private void OnDrawGizmos() //Draw the sphere on the gizmo
    {
        for (int i = 0; i < animatedVectors.Count; i++)
        {
            float t = Mathf.InverseLerp(0, animatedVectors.Count, i);
            Gizmos.color = Color.Lerp(startColor, endColor, t);
            Vector3 targetPos = transform.TransformPoint(animatedVectors[i].point) * radius;
            Gizmos.DrawSphere(targetPos, pointSize);
        }
    }

}
