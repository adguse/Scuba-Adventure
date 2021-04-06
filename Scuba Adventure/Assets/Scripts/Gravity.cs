using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{
    [SerializeField] private float gravityScale;
    private const float globalGravity = -9.81f;
    private new Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        body.useGravity = false;
    }

    private void FixedUpdate()
    {
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        body.AddForce(gravity, ForceMode.Acceleration);
    }
}
