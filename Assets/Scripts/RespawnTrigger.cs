using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnTrigger : MonoBehaviour
{
    private bool isTriggered = false;
    private float delay;
    //Sound
    public AudioClip[] sounds;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTriggered = true;
            delay = 2f;
            // Play audio for Losing here
            source.clip = sounds[0];
            source.Play();
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
