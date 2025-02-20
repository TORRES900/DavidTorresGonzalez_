using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{

    [SerializeField]
    private GameObject player;
    private NavMeshAgent agent;

    private void Awake()
    {

        player = GameObject.FindGameObjectWithTag("PlayerTank");
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        
        if(player == null)
        {

            return;

        }

        GetPlayer();

    }

    private void GetPlayer()
    {
        
        agent.SetDestination(player.transform.position);

    }
}
