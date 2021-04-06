using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SwimmingController : MonoBehaviour
{
    [SerializeField] private float swimmingForce;
    [SerializeField] private float resistanceForce;
    [SerializeField] private float deadZone;
    [SerializeField] private Transform trackingSpace;

    private new Rigidbody body;
    private Vector3 currentDirection;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        bool rightButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        bool leftButtonPressed = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch);

        if(rightButtonPressed && leftButtonPressed)
        {
            Vector3 leftHandDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.LTouch);
            Vector3 rightHandDirection = OVRInput.GetLocalControllerVelocity(OVRInput.Controller.RTouch);
            Vector3 localVelocity = leftHandDirection + rightHandDirection;
            localVelocity *= -1f;
            
            if(localVelocity.sqrMagnitude > deadZone * deadZone)
            {
                AddSwimmingForce(localVelocity);
            }
        }

        ApplyResistance();
    }

    private void ApplyResistance()
    {
        if(body.velocity.sqrMagnitude > 0.01f && currentDirection != Vector3.zero)
        {
            body.AddForce(-body.velocity * resistanceForce, ForceMode.Acceleration);
        }
        else
        {
            currentDirection = Vector3.zero;
        }
    }

    private void AddSwimmingForce(Vector3 localVelocity)
    {
        Vector3 worldVelocity = trackingSpace.TransformDirection(localVelocity);
        body.AddForce(worldVelocity * swimmingForce, ForceMode.Acceleration);
        currentDirection = worldVelocity.normalized;

    }
}
