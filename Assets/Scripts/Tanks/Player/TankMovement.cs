using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float turnSpeed;

    private float horizontal,
                  vertical;
    private Rigidbody rb;

    [Header("Sound")]
    [SerializeField]
    private AudioClip idleClip;
    [SerializeField]
    private AudioClip drivingClip;

    private AudioSource audioSource;

    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }


    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        Move();
        Turn();

    }

    void Update()
    {

        InputsPlayer();
        AudioPlayer();


    }

    private void InputsPlayer()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

    }

    private void Move()
    {

        Vector3 direction = transform.forward * vertical * speed * Time.deltaTime;
        rb.MovePosition(transform.position + direction);

    }

    private void Turn()
    {

        float turn = horizontal * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, horizontal, 0.0f);
        rb.MoveRotation(transform.rotation * turnRotation);

    }

    private void AudioPlayer()
    {

        if(vertical != 0.0f || horizontal != 0.0f) 
        {

            if (audioSource.clip != drivingClip)
            {

                audioSource.clip = drivingClip;
                audioSource.Play();

            }
            else
            {

                if (audioSource.clip != idleClip)
                {

                    audioSource.clip = idleClip;
                    audioSource.Play();

                }

            }
        }

    }
}
