using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTanks : MonoBehaviour
{

    public Transform Target;
    [Header("Vectors")]
    [SerializeField]
    private float smoothing;

    [SerializeField]
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

        offset = transform.position - Target.position;

    }

    private void LateUpdate()
    {

        Vector3 desiredPosition = Target.position + offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothing * Time.deltaTime);

    }
}

