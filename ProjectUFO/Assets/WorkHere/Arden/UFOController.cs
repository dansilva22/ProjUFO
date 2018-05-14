using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public float inputDelay = 0.1f;
    public float forwardVelocity = 12;
    public float rotateVelocity = 60;

    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput, pitchInputDown, pitchInputUp;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }

    }

    void Start()
    {
        //targetRotation = transform.rotation;
        
        //check if object has a rigidbody, prints if you do not
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("NO RIGIDBODY FOOL");

        forwardInput = turnInput = pitchInputDown = pitchInputUp = 0;

    }

    void GetInput()
    {
        //saves inputs into variables
        forwardInput = Input.GetAxis("Forward");
        turnInput = Input.GetAxis("Yaw");
        pitchInputUp = Input.GetAxis("PitchHoldDown");
        pitchInputDown = Input.GetAxis("PitchHoldUp");
        //pitches named wrongly right now because fucked up input axis, will fix later. Must swap PitchHolds in input manager
    }

    void Update()
    {
        GetInput();
        Turn();
        PitchHold();
        PitchHoldNegative();

    }

    void FixedUpdate()
    {

        Thrusters();

    }

    void Thrusters()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //move it move it
            rBody.velocity = transform.forward * forwardInput * forwardVelocity;
        }
        else
            // zero velocity
            rBody.velocity = Vector3.zero;
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            // turns UFO after input delay
            rBody.AddTorque(Vector3.up * turnInput * 0.8f);
        }
        else
            // zero velocity
            rBody.angularVelocity = Vector3.zero;
    }

    void PitchHold()
    {
        if (Mathf.Abs(pitchInputDown) > inputDelay)
        {
            // pitches UFO up
            rBody.rotation *= Quaternion.AngleAxis(rotateVelocity * pitchInputDown * Time.deltaTime, Vector3.right);
        }
    }

    void PitchHoldNegative()
    {
        if (Mathf.Abs(pitchInputUp) > inputDelay)
        {
            //pitches UFO down
            rBody.rotation *= Quaternion.AngleAxis(rotateVelocity * pitchInputUp * Time.deltaTime, Vector3.left);
            

        }
    }
}