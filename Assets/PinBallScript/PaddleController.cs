using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    //public float springPower;
    private HingeJoint joint;
    private float targaetPressed;
    private float targaetReleased;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint>();
        targaetPressed = joint.limits.max;
        targaetReleased = joint.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointSpring = joint.spring;
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = targaetPressed;
        }
        else
        {
            jointSpring.targetPosition = targaetReleased;
        }
        joint.spring = jointSpring;
    }
}
