//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortRangedTeleport : MonoBehaviour
{
    public Transform playerPos;
    public bool shortOnCooldown;
    private float baseCooldown;
    public float shortCooldown = 3f;
    public KeyCode m_short;
    public float shortTeleport = 7.5f;
    //Sound
    public AudioClip[] sounds;
    private AudioSource source;
    
    void Start()
    {
        shortOnCooldown = false;

        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        ShortTeleport();
    }
    void ShortTeleport()
    {
        if (Input.GetKeyDown(m_short) && shortOnCooldown == false) // Activates Short-Ranged Teleportation
        {
            playerPos.transform.position += playerPos.transform.forward * shortTeleport; // Teleport
            // Play audio for teleport activation here
            source.clip = sounds[Random.Range(0, 2)];
            source.PlayOneShot(source.clip);
            //Sound
            shortOnCooldown = true;
            
            baseCooldown = shortCooldown; // Cooldown reset
        }
         else if (shortOnCooldown == true) // Cooldown calculations
        {
            baseCooldown -= Time.deltaTime;
            if (baseCooldown <= 0)
            {
                shortOnCooldown = false;
                source.clip = sounds[3];
                source.PlayOneShot(source.clip);

            }
            else
            {
                if (Input.GetKeyDown(m_short))
                {
                    source.clip = sounds[2];
                    source.Play();
                    
                }
                // Play audio for teleport cooldown currently active here
            }
        }
    }
}
