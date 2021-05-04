using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OVRGrabbable))]

public class item : MonoBehaviour
{
    public itemCounter counter;
    private OVRGrabbable treasure;
    private Rigidbody body;

    private void Awake() {
        treasure = GetComponent<OVRGrabbable>();
        body = GetComponent<Rigidbody>();
    }
    

    private void FixedUpdate() {
        if(treasure.isGrabbed){
            body.useGravity = false;
            counter.decreaseCounter();
            Destroy(this);
            Destroy(gameObject,5);
        }
    }
}
