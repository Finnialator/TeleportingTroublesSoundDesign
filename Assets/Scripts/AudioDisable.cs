using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDisable : MonoBehaviour
{
    public GameObject objectToggle;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectToggle.SetActive(false);
        }
    }
}
