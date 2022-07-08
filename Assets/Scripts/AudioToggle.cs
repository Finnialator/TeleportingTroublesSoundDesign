using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    public GameObject objectToggle;

    private void Awake()
    {
        objectToggle.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToggle.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToggle.SetActive(false);
        }
    }
}
