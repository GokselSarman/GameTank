using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Transform shellSpawn;
    public GameObject shellPrefab;
    public bool isAI;
    // public GameObject particlePrefab;

    AudioSource audioSource;




    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (isAI) return;
       
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
        
        
    }
    float nextShoot = 1f;
    public void Shoot()
    {

        if (Time.time>nextShoot)
        {
            audioSource.Play();
            GameObject shell = Instantiate(shellPrefab, shellSpawn.position, Quaternion.identity);
            /*GameObject particle = Instantiate(particlePrefab, transform);
            Destroy(particle, 3);*/
            shell.GetComponent<Rigidbody>().velocity = transform.forward * 7000f * Time.deltaTime;
            nextShoot = Time.time + 0.2f;
            
        }

        

    }
}
