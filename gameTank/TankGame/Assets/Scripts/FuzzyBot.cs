﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AForge;
using AForge.Fuzzy;
using System;


public class FuzzyBot : MonoBehaviour
{




    public Transform player;


    float speed, distance;
    FuzzySet fsNear, fsMed, fsFar;
    FuzzySet fsSlow, fsMedium, fsFast;
    LinguisticVariable lvDistance, lvSpeed;

    Database database;
    InferenceSystem infSystem;

    // Start is called before the first frame update
    void Start()
    {
        Initializate();

      
    }

    private void Initializate()
    {
        SetDistanceFuzzySets();
        SetSpeedFuzzySets();
        AddRulesTODataBase();
    }



    private void SetDistanceFuzzySets()
    {
        fsNear = new FuzzySet("Near", new TrapezoidalFunction(20, 40, TrapezoidalFunction.EdgeType.Right));
        fsMed = new FuzzySet("Med", new TrapezoidalFunction(20, 40, 50, 70));
        fsFar = new FuzzySet("Far", new TrapezoidalFunction(50, 70, TrapezoidalFunction.EdgeType.Left));

        lvDistance = new LinguisticVariable("Distance", 0, 120);
        lvDistance.AddLabel(fsNear);
        lvDistance.AddLabel(fsMed);
        lvDistance.AddLabel(fsFar);
        
    }
    
    private void SetSpeedFuzzySets()
    {
        fsSlow = new FuzzySet("Slow", new TrapezoidalFunction(30, 50, TrapezoidalFunction.EdgeType.Right));
        fsMedium = new FuzzySet("Medium", new TrapezoidalFunction(30, 50, 80, 100));
        fsFast = new FuzzySet("Fast", new TrapezoidalFunction(80, 100, TrapezoidalFunction.EdgeType.Left));
        lvSpeed = new LinguisticVariable("Speed", 0, 120);

        lvSpeed.AddLabel(fsSlow);
        lvSpeed.AddLabel(fsMedium);
        lvSpeed.AddLabel(fsFast);
    }


    private void AddRulesTODataBase()
    {
        database = new Database();
        database.AddVariable(lvDistance);
        database.AddVariable(lvSpeed);
        SetRules();  
    }

    private void SetRules()
    {
        infSystem = new InferenceSystem(database, new CentroidDefuzzifier(120));
        infSystem.NewRule("Rule 1", "IF Distance IS Near THEN Speed IS Slow");
        infSystem.NewRule("Rule 2", "IF Distance IS Med THEN Speed IS Medium");
        infSystem.NewRule("Rule 3", "IF Distance IS Far THEN Speed IS Fast");
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        float distance = (player.position - transform.position).magnitude;


        

       Quaternion rot = Quaternion.LookRotation(dir);
        
        infSystem.SetInput("Distance", distance);
        speed = infSystem.Evaluate("Speed");
       

       

         transform.position += dir * speed * Time.deltaTime*0.5f;
          transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.3f);
        Debug.Log(speed);
    }
}
