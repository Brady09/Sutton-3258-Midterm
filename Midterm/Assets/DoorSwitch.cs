using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject doorObject;
    public AudioClip switchSound; 
    public ParticleSystem particleEffect; 
    public float destroyDelay = 2f; 

    private AudioSource audioSource;

    private void Start()
    {
        
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = switchSound;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (doorObject != null)
        {
            PlaySwitchSound();
            PlayParticleEffect();
            DisableCollidersAndRenderers();
            Destroy(doorObject, destroyDelay);
        }
    }

    private void PlaySwitchSound()
    {
        if (switchSound != null)
        {
            audioSource.Play();
        }
    }

    private void PlayParticleEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.Play();
        }
    }

    private void DisableCollidersAndRenderers()
    {
        Collider[] colliders = doorObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        Renderer[] renderers = doorObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }
    }
}