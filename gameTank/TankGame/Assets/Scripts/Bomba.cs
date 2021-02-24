using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{


    private void Update()
    {
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
       
        Health health = collision.gameObject.GetComponent<Health>();
        nesneHealth nesneHealth = collision.gameObject.GetComponent<nesneHealth>();

        if (health)
        {
            health.TakeDamage(20);
        }
        if (nesneHealth)
        {
            nesneHealth.TakeDamage(20);

        }

        Destroy(gameObject);
    }

}
