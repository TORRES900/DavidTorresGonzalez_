using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{

    [SerializeField]
    private Rigidbody shellPrefab;

    [SerializeField]
    private Transform posShell;

    [SerializeField]
    private float launchForce;

    [SerializeField]
    private AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {

        InputPlayer();

    }



    private void InputPlayer()
    {

        if(Input.GetMouseButtonDown(0))
        {

            Launch();

        }

    }

    private void Launch()
    {

        Rigidbody cloneShellPrefab = Instantiate(shellPrefab, posShell.position, posShell.rotation);

        audioSource.Play();

        cloneShellPrefab.velocity = posShell.forward * launchForce;

    }
}
