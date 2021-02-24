using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    public Transform[] waypoints;
    NavMeshAgent agent;
    public Transform rayOrigin;

    Vector3[] wayPointsPos = new Vector3[3];

    Animator fsm;

    Vector3 nextPoint;
    int currentIndex;

    float field;

    Transform player;

    public bool enemy1;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        field = 120f;
        fsm = GetComponent<Animator>();


        for (int i = 0; i < waypoints.Length; i++)
            wayPointsPos[i] = waypoints[i].position;


        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(wayPointsPos[currentIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceWayPoints = Vector3.Distance(transform.position, wayPointsPos[currentIndex]);
        fsm.SetFloat("distanceWay", distanceWayPoints);

        float angle = GetAngle();

        Vector3 dir = (player.position - transform.position).normalized;
        float distance = (player.position - transform.position).magnitude;


        if (enemy1 == true)
        {
            if (angle < field)
            {
                RaycastHit hitInfo;
                if (Physics.Raycast(rayOrigin.position, dir, out hitInfo, 100f))
                {

                    fsm.SetFloat("distance", distance);

                    Debug.DrawRay(rayOrigin.position, dir * 100f, Color.red);

                    if (hitInfo.transform.tag == "Player")
                    {
                        fsm.SetBool("visible", true);
                    }
                    else
                    {
                        fsm.SetBool("visible", false);
                    }
                }
            }
            else
            {
                fsm.SetBool("visible", false);
            }

        }
        if(enemy1==false)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(rayOrigin.position, dir, out hitInfo, 100f))
            {

                fsm.SetFloat("distance", distance);

                Debug.DrawRay(rayOrigin.position, dir * 50f, Color.red);

                if (hitInfo.transform.tag == "Player")
                {
                    fsm.SetBool("visible", true);
                }
                else
                {
                    fsm.SetBool("visible", false);
                }
                // fsm.SetBool("visible", false);
            }
        }
        
    }


    public void Chase()
    {
       /* Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * 5f * Time.deltaTime;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.3f);*/
        agent.SetDestination(player.position);
    }

    public void Shoot()
    {
        
        gameObject.GetComponent<TankShoot>().Shoot();
    }

    public void Patrol()
    {
        agent.SetDestination(wayPointsPos[currentIndex]);
    }

    private float GetAngle()
    {
        Vector3 dir = player.position - transform.position;
        float cos = Vector3.Dot(transform.forward, dir) / (transform.forward.magnitude * dir.magnitude);
        float angle = Mathf.Acos(cos);
        return angle * Mathf.Rad2Deg;
    }

    

    public void FindNewPoint()
    {
        /*int rand = Random.Range(0, 3);
        currentIndex = rand;*/

        switch (currentIndex)
        {
            case 0:
                currentIndex = 1;
                break;
            case 1:
                currentIndex = 2;
                break;
            case 2:
                currentIndex = 0;
                break;
        }

        agent.SetDestination(wayPointsPos[currentIndex]);
    }

    public void MoveToTarget()
    {
        agent.SetDestination(wayPointsPos[currentIndex]);
        
        
    }

    public void SetLookRotation()
    {
        
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * 5f * Time.deltaTime;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.2f);

    }
}
