using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//YOUTUBE LINK
//www.youtube.com/watch?v=3uyolYVsiWc

public class Health : MonoBehaviour
{
    public int currentMaskPoints;
    public int maxMaskPoints;

    public Image[] masks;
    public Sprite fullMask;
    public Sprite emptyMask;

    public CheckpointScript respawn;

    void Awake()
    {
    	currentMaskPoints = maxMaskPoints;
        //if (healthbar != null)
        //    healthbar.fillAmount = 1.0f;
    }

    void Update()
    {
        if(currentMaskPoints > maxMaskPoints)
        {
            currentMaskPoints = maxMaskPoints;
        }


        for(int i = 0; i < masks.Length; i++)
        {
            if(i < currentMaskPoints)
            {
                masks[i].sprite = fullMask;
            }
            else
            {
                masks[i].sprite = emptyMask;
            }


            if(i < maxMaskPoints)
            {
                masks[i].enabled = true;
            }
            else
            {
                masks[i].enabled = false;
            }
        }
    }


    //THIS IS WHEN YOU MAKE CONTACT WITH AN INFECTED. YOU LOOSE 1 MASK.
    public void InfectedTakeDamage()
    {
        currentMaskPoints -= 1;
        
        Debug.Log("takingdamage");
        //animator.SetTrigger("isHit");
        if (currentMaskPoints < 1)
        {
            respawn.spawnAgain();
            //this.gameObject.SetActive(false);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void PoliceTakeDamage() {
        currentMaskPoints -= 3;

        Debug.Log("takingdamage");
        //animator.SetTrigger("isHit");
        if (currentMaskPoints < 1) {
            respawn.spawnAgain();
            //this.gameObject.SetActive(false);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //WHEN YOU MAKE CONTACT ON WITH A POLICE. SENDS YOU BACK TO CHECKPOINT.
    public void ReturnCheckpoint()
    {

    }

    //WHEN YOU MAKE CONTACT OF A CHECKPOINT. KEEPS TRACK OF COORDS
    public void CheckpointCheck(float xpos, float ypos)
    {

    }


    //WHEN YOU ARRIVE AT A MERCURY DRUG CHECKPOINT.
    public void FullRestore()
    {
        currentMaskPoints = maxMaskPoints;
    }    
}
