using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    public GameManager GameManagerScript;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("John"))
        {

            Debug.Log("Te pillé!");
            GameManagerScript.IsPlayerCaught = true;

        }

    }
}
