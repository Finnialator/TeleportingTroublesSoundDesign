//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangedTeleport : MonoBehaviour
{
    public Transform playerPos;
    public bool longOnCooldown;
    private float baseCooldown;
    public float longCooldown = 10f;
    public KeyCode m_long;
    //Sound
    public AudioClip[] sounds;
    private AudioSource source;
    void Start()
    {
        longOnCooldown = false;
        source = GetComponent<AudioSource>();
    }
    void LongTeleport()
    {
        if (Input.GetKeyDown(m_long) && longOnCooldown == false) // Activates Long-Range Teleportation
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Finding point to teleport to
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000))
            {
                playerPos.transform.position = hit.point; // Teleport
                // Play audio for teleport activation here
                source.clip = sounds[Random.Range(0, 2)];
                source.PlayOneShot(source.clip);
                //Sound
                longOnCooldown = true;
                baseCooldown = longCooldown; // Cooldown reset
            }
        }
        else if (longOnCooldown == true) // Cooldown calculations
        {
            baseCooldown -= Time.deltaTime;
            if (baseCooldown <= 0)
            {
                longOnCooldown = false;
                source.clip = sounds[3];
                source.PlayOneShot(source.clip);
            }
            else
            {
                if (Input.GetKeyDown(m_long))
                {
                    source.clip = sounds[2];
                    source.Play();

                }
                // Play audio for teleport cooldown currently active here
            }
        }
    }
    void Update()
    {
        LongTeleport();   
    }
}
