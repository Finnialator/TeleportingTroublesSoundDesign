using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour
{
    private bool isTriggered = false;
    private float delay;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            delay = 3f;
            // Play audio for Losing here
        }
    }
    private void Update()
    {
        Triggered();
    }
    void Triggered()
    {
        if (isTriggered == true)
        {
            delay -= Time.deltaTime;
            if (delay <= 0)
            {
                SceneManager.LoadScene("TeleportingTroubles");
            }
        }
    }
}
