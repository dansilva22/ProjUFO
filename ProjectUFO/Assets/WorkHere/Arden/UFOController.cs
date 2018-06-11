using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public float inputDelay = 0.1f;
    public float forwardVelocity = 12;
    public float pitchVelocity = 60;
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

        //says if the player needs a rigidbody
        if (GetComponent<Rigidbody>())
            rBody = GetComponent<Rigidbody>();
        else
            Debug.LogError("get a rigidbody fool");

        forwardInput = turnInput = pitchInputDown = pitchInputUp = 0;

    }

    void GetInput()
    {
        //parses input into variables
        forwardInput = Input.GetAxis("Forward");
        turnInput = Input.GetAxis("Yaw");
        pitchInputDown = Input.GetAxis("PitchHoldDown");
        pitchInputUp = Input.GetAxis("PitchHoldUp");
     
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
            //move it move it forward using [w]
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
            //turns dat jawn using [a] & [d] respectively
            rBody.AddTorque(rotateVelocity * Vector3.up * turnInput);
        }
        //else if (Mathf.Abs(turnInput) > 80)
        //{
            //rBody.angularVelocity = rBody.angularVelocity * rotateVelocity;

        //}
        else
        {
            // slow velocity
            rBody.angularVelocity = rBody.angularVelocity * rotateVelocity;
        }
    }

    void PitchHold()
    {
        if (Mathf.Abs(pitchInputUp) > inputDelay)
        {
            //pitches UFO up using [right click]
            rBody.rotation *= Quaternion.AngleAxis(pitchVelocity * pitchInputUp * Time.deltaTime, Vector3.left);

        }
        //else
            // slow velocity
            //rBody.rotation *= Quaternion.AngleAxis(pitchVelocity * pitchInputUp * Time.deltaTime, Vector3.left * 0.75f);
    }

    void PitchHoldNegative()
    {
        if (Mathf.Abs(pitchInputDown) > inputDelay)
        {
            //pitches UFO down using [left click]
            rBody.rotation *= Quaternion.AngleAxis(pitchVelocity * pitchInputDown * Time.deltaTime, Vector3.right);
        }
        //else
            // slow velocity
            //rBody.rotation *= Quaternion.AngleAxis(pitchVelocity * pitchInputDown * Time.deltaTime, Vector3.right * 0.75f);
    }

    //void OnCollisionEnter(Collision collision)
    //{
        //if (collision.gameObject.tag == "environment")
        //{
            //rBody.isKinematic = true;
           // rBody.isKinematic = false;
        //}


   // }
}