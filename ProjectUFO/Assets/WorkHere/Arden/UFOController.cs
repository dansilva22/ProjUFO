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
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("Character needs a rigidbody.");

        forwardInput = turnInput = pitchInputDown = pitchInputUp = 0;

    }

    void GetInput()
    {
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
            //transform.eulerAngles += new Vector3(forwardInput, 0.0f, 0.0f);
            //transform.Rotate(30 * Time.deltaTime, 0, 0); 
            //targetRotation *= Quaternion.AngleAxis(rotateVelocity * turnInput * Time.deltaTime, Vector3.down);
            //transform.rotation = targetRotation;
        }
        else
            // zero velocity
            rBody.velocity = Vector3.zero;
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            //transform.Rotate(0, 30 * Time.deltaTime, 0);
            //targetRotation *= Quaternion.AngleAxis(rotateVelocity * turnInput * Time.deltaTime, Vector3.up);
            //transform.eulerAngles += new Vector3(0.0f, turnInput, 0.0f);
            //transform.rotation = targetRotation;
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
            //transform.Rotate(0, 30 * Time.deltaTime, 0);
            //targetRotation *= Quaternion.AngleAxis(rotateVelocity * turnInput * Time.deltaTime, Vector3.up);
            //transform.eulerAngles += new Vector3(forwardInput, 0.0f, 0.0f);
            rBody.rotation *= Quaternion.AngleAxis(rotateVelocity * pitchInputDown * Time.deltaTime, Vector3.right);
            //rBody.AddTorque(Vector3.right * pitchInputDown * 0.5f);
            //transform.rotation = targetRotation;
        }
        //else
        // zero velocity
        //rBody.angularVelocity = Vector3.zero;

    }

    void PitchHoldNegative()
    {
        if (Mathf.Abs(pitchInputUp) > inputDelay)
        {
            //transform.Rotate(0, 30 * Time.deltaTime, 0);
            //targetRotation *= Quaternion.AngleAxis(rotateVelocity * turnInput * Time.deltaTime, Vector3.up);
            //transform.eulerAngles += new Vector3(-1 * forwardInput, 0.0f, 0.0f);
            rBody.rotation *= Quaternion.AngleAxis(rotateVelocity * pitchInputUp * Time.deltaTime, Vector3.left);
            //rBody.AddTorque(Vector3.back * pitchInputUp * 0.5f);
            //transform.rotation = targetRotation;

        }
        //else
        // zero velocity
        // rBody.angularVelocity = Vector3.zero;
    }
}