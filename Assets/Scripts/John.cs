using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField]
    private float speed,
                  turnSpeed;

    [SerializeField]
    private Vector3 direction;

    private Rigidbody rb;
    private Animator anim;
    private AudioSource audioSource;
    private float horizontal,
                    vertical;


    private void Awake()
    {

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {

        Rotation();

    }

    private void OnAnimatorMove()
    {
        
        rb.MovePosition(transform.position + (direction * anim.deltaPosition.magnitude));

    }
    void Update()
    {

        InputsPlayer();
        IsAnimate();
        AudioSteps();

    }

    private void InputsPlayer()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(-horizontal, 0.0f, -vertical);
        direction.Normalize();

    }

    private void IsAnimate()
    {

        if(horizontal != 0.0f || vertical != 0.0f)
        {

            anim.SetBool("isWalking", true);

        }
        else
        {

            anim.SetBool("isWalking", false);

        }

    }

    private void Rotation()
    {

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, direction, turnSpeed * Time.deltaTime, 0.0f);
        Quaternion rotation = Quaternion.LookRotation(desiredForward);
        rb.MoveRotation(rotation);

    }

    private void AudioSteps()
    {

        if(horizontal == 0.0f || vertical == 0.0f)
        {
            if(audioSource.isPlaying == false)
            {

                audioSource.Play();

            }

        }
        else
        {

            audioSource.Stop();

        }
    }
}
