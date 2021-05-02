using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OVRGrabbable))]

public class item : MonoBehaviour
{
    public itemCounter counter;
    private OVRGrabbable treasure;

    private void Awake() {
        treasure = GetComponent<OVRGrabbable>();
    }
    
    private void OnCollisionEnter(Collision other) {
        counter.decreaseCounter();
    }

    private void FixedUpdate() {
        if(treasure.isGrabbed){
            counter.decreaseCounter();
            Destroy(this);
            Destroy(gameObject,5);
        }
    }
}
