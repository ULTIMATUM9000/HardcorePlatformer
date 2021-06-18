using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceScript : EnemiesDetection
{

    // [SerializeField] Transform targetPosition; // position of player
    // [SerializeField] Transform currentPosition; //position of AI
    // [SerializeField] float speedAI; 
    // [SerializeField] float maxRangeDetection; // range before the enemy starts following the player
    // [SerializeField] float minRangeDetection;
    // [SerializeField] LayerMask somethingLayer;
    // [SerializeField] Vector2 passivePoint1;
    // [SerializeField] Vector2 passivePoint2;
    // [SerializeField] bool passiveModeState;

    void Start()
    {
        //transform.position = currentPosition.position;
    }

    void Update()
    {
        // Debug.Log(passiveModeState);
        // if (Vector2.Distance(currentPosition.position, targetPosition.position) < maxRangeDetection && Vector2.Distance(currentPosition.position, targetPosition.position) > minRangeDetection) 
        // {

        //     passiveModeState = false;
        //     currentPosition.position = Vector2.MoveTowards(currentPosition.position, new Vector2(targetPosition.position.x, currentPosition.position.y), speedAI * Time.deltaTime);
        // } 
        // else 
        // {

        //     passiveModeState = true;
        //     PassiveMode();
        // }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.PoliceTakeDamage();
        }
    }

    void PassiveMode() 
    {

        // float timerBeforeSwitching = 0.0f; // gives the ai a certain pause at that position before moving elsewhere

        // if (passiveModeState) 
        // {

        //   // currentPosition.position = Vector2.Lerp(currentPosition.position, passivePoint1, 1);
        //     if (currentPosition.position.x < passivePoint1.x) 
        //     { //passivePoint1 holds the coordinate for the 1st position of where the ai is going to stop
        //         timerBeforeSwitching += Time.deltaTime;

        //         currentPosition.position = Vector2.SmoothDamp(transform.position, passivePoint1,ref passivePoint2, 5.0f);
 
                
        //     }
        // }
    }

    
}
            //   //if (timerBeforeSwitching < 1.0f) {

            //    ////    currentPosition.position = Vector2.Lerp(passivePoint1, passivePoint2, 1.0f);
                       
                    
            //    //} else {

            //    //    timerBeforeSwitching = 0.0f;
            //    //}
                

            //}
            //if (currentPosition.position.x > passivePoint2.x) { //passivePoint2 holds the coordinate for the 2nd position of where the ai is going to stop
            //    timerBeforeSwitching += Time.deltaTime;

            //    if (timerBeforeSwitching< 1.0f) {

            //        currentPosition.position = Vector2.Lerp(passivePoint2, passivePoint1, 0.0f);
            //    } else {

            //        timerBeforeSwitching = 0.0f;
            //    }