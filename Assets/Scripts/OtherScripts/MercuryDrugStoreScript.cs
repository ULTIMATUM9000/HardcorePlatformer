using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercuryDrugStoreScript : MonoBehaviour
{
    Health mercuryDetects;
   

    void Start() 
    {

        mercuryDetects = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    public void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
        {
            mercuryDetects.FullRestore();
        }
    }
}
