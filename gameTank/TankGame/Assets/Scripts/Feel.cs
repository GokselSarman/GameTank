using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Feel : MonoBehaviour
{
    bool isFeel;
    Animator fsm;
    public Transform player;
    public Transform rayOrigin;

    NavMeshAgent agent;



    void Start()
    {
        fsm = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Look()
    {
        agent.SetDestination(player.position);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            
            fsm.SetBool("isFeel", true);

        }
      
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            fsm.SetBool("isFeel", true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {

            fsm.SetBool("isFeel", false);

        }
    }
}
