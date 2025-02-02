using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    [Header("WayPoints")]

    [SerializeField]
    private Transform[] positionsArray;
    [SerializeField]
    private float speed;

    private Vector3 posToGo;

    private int i;
    private Ray ray;
    private RaycastHit hit;

    public GameManager GameManagerScript;


    void Start()
    {

        i = 0;
        posToGo = positionsArray[i].position;

    }

    private void FixedUpdate()
    {

        DetectionJohn();

    }

    // Update is called once per frame
    void Update()
    {

        Move();
        ChangePosition();
        Rotate();

    }

    private void Move()
    {

        transform.position = Vector3.MoveTowards(transform.position, posToGo, speed * Time.deltaTime);

    }

    private void ChangePosition()
    {

        if(Vector3.Distance(transform.position, posToGo) <= Mathf.Epsilon)
        {

            if(i == positionsArray.Length - 1)
            {

                i = 0;

            }
            else
            {

                i++;

            }

            posToGo = positionsArray[i].position;

        }

    }

    private void Rotate()
    {

        transform.LookAt(posToGo);

    }

    private void DetectionJohn()
    {

        ray.origin = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        ray.direction = transform.forward;

        if(Physics.Raycast(ray, out hit))
        {

            if (hit.collider.CompareTag("John"))
            {

                Debug.Log("El fantasma te ha pillado!");
                GameManagerScript.IsPlayerCaught = true; 

            }

        }


    }
}

