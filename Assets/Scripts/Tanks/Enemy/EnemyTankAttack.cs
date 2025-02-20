using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class EnemyTankAttack : MonoBehaviour
{
    [Header("Time")]
    [SerializeField]
    private float timer;
    [SerializeField]
    private float timeBetweenAttacks;

    private bool isAttack;

    [Header("Prefab")]
    [SerializeField]
    private Rigidbody shellEnemyPrefab;
    [SerializeField]
    private Transform posShell;
    [SerializeField]
    private float launchForce;
    [SerializeField]
    private float factorLaunchForce;

    [Header("RayCast")]
    private Ray ray;
    private RaycastHit hit;
    [SerializeField]
    private float distance;
    
    private void Awake()
    {
        
        isAttack = false;

    }


    private void FixedUpdate()
    {
        
        if(isAttack)
        {

            Launch();
            isAttack = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        CountTimer();

    }

    private void CountTimer()
    {

        ray.origin = transform.position;
        ray.direction = transform.forward;

        timer += Time.deltaTime;

        if(Physics.Raycast(ray, out hit))
        {

            if (hit.collider.CompareTag("PlayerTank") && timer >= timeBetweenAttacks)
            {

                timer = 0.0f;
                isAttack = true;
                distance = hit.distance;

            }

        }


    }


    private void Launch()
    {

        float launchForceFinal = launchForce * distance * factorLaunchForce;
        Rigidbody cloneShellPrefab = Instantiate(shellEnemyPrefab, posShell.position, posShell.rotation);
        cloneShellPrefab.velocity = posShell.forward * launchForceFinal;

    }
}
