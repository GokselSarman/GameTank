using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class tank : MonoBehaviour
{

    float minX = -10, maxX = 10, minZ = -10, maxZ = 10;
    Vector3 nextPoint;
    
    

    
    void Update()
    {

        if (Vector3.Distance(nextPoint, transform.position) < 0.1f)
        {
            FindNewPoint();

        }

        GoToPoint();
        
    }

    private void GoToPoint()
    {
        Vector3 dir = (nextPoint - transform.position).normalized;
        transform.position += dir * 5.0f * Time.deltaTime;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 1f);
    }

    private void FindNewPoint()
    {
        float randX = Random.Range(minX, maxX);
        float randZ = Random.Range(minZ, maxZ);
        nextPoint = new Vector3(randX, transform.position.y, randZ);
    }
}
