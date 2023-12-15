using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathzone : MonoBehaviour
{
    private int lastCheckpointID = 0; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerDeath(collision.gameObject);
        }
    }

    void PlayerDeath(GameObject player)
    {
        float checkpointX = PlayerPrefs.GetFloat("CheckpointX_" + lastCheckpointID, 0f);
        float checkpointY = PlayerPrefs.GetFloat("CheckpointY_" + lastCheckpointID, 0f);
        float checkpointZ = PlayerPrefs.GetFloat("CheckpointZ_" + lastCheckpointID, 0f);

        player.transform.position = new Vector3(checkpointX, checkpointY, checkpointZ);

        lastCheckpointID = 0; 
    }
}
