using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public int checkpointID; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SaveCheckpointPosition(other.gameObject);
        }
    }

    void SaveCheckpointPosition(GameObject player)
    {
        PlayerPrefs.SetFloat("CheckpointX_" + checkpointID, player.transform.position.x);
        PlayerPrefs.SetFloat("CheckpointY_" + checkpointID, player.transform.position.y);
        PlayerPrefs.SetFloat("CheckpointZ_" + checkpointID, player.transform.position.z);
    }
}