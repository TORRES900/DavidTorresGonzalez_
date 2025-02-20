using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem explosionShell;

    private AudioSource audioSource;
    private Collider coll;
    private Renderer rend;

    private void Awake()
    {
        
        audioSource = GetComponent<AudioSource>();
        coll = GetComponent<Collider>();
        rend = GetComponent<Renderer>();

    }

    private void OnCollisionEnter(Collision infoCollision)
    {
        
        coll.enabled = false;
        rend.enabled = false;
        explosionShell.Play();
        audioSource.Play();
        Destroy(gameObject, 0.5f);

    }

}
