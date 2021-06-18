using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointScript : MonoBehaviour
{
    public Vector2 playerCheckpoint;
    public Vector2 checkPoint;
    public Transform playerPos;

    public Health masks;
    public int currentMaskCheckpoint;
    public TextMeshProUGUI checkpointText;

    public int timePutOut;

    private void Awake() {

        checkpointText.enabled = false;
        playerCheckpoint = checkPoint;
        currentMaskCheckpoint = masks.maxMaskPoints;
    }
    public void OnTriggerEnter2D(Collider2D other) {

        
        if (other.CompareTag("Player")) {
            Debug.Log("Player checkpoint reached");
            checkPoint = transform.position;
            currentMaskCheckpoint = masks.currentMaskPoints;
            checkpointText.enabled = true;
            Destroy(checkpointText, timePutOut);
        }
    }

    public void spawnAgain() {

        playerPos.position = checkPoint;
       masks.currentMaskPoints = currentMaskCheckpoint;
    }
}
