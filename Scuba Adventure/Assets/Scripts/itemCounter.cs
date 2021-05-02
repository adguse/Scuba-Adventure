using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class itemCounter : MonoBehaviour
{

    private Text text;
    protected int counter;
    public CapsuleCollider body;

    public OVRGrabbable objefct;


    private void Awake()
    {
        text = GetComponent<Text>();
        counter = 20;
    }

    private void FixedUpdate() {
        text.text = "Items remaining: " + counter;
    }

    public void decreaseCounter(){
        counter --;
    }

}
