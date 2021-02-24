using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nesneHealth : MonoBehaviour
{
    
    float health = 100;



    public void TakeDamage(float amount)
    {

        health -= amount;
      
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
