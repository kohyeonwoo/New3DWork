using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    public Transform target;

    private Vector3 offset;

    private void Start()
    {
        offset = target.position - this.transform.position;
    }

    private void FixedUpdate()
    {
        this.transform.position = target.position - offset;
    }
}
