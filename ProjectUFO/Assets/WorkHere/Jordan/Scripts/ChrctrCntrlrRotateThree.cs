using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrctrCntrlrRotateThree : MonoBehaviour {

    //Movement speed  for Meeples
    public float movementSpeed = 4;

    //How fast the movement speed increases over time
    public float speedIncrement = 0.08f;

    //Max possible speed
    public float maximumSpeed = 24f;

    private float timer = 0.0f;

    //Speed of bobbing of Meeples
    public float bobbingSpeed = 0.18f;

    //How much the Meeples bob
    public float bobbingAmount = 0.2f;

    //Where the bobbing starts and ends
    public float midpoint = 0.0f;

    private void Start()
    {
    }

    private void Update()
    {

        //Increase movement speed
        movementSpeed += speedIncrement;

        //Check is movementSpeed is the maximumSpeed
        if (movementSpeed >= maximumSpeed) movementSpeed = maximumSpeed;

        //Setting up axes
        float moveHorizontal = Input.GetAxisRaw("Player3_Horizontal");
        float moveVertical = Input.GetAxisRaw("Player3_Vertical");

        //Connect input axis to Meeples locations
        Vector3 movement = new Vector3(moveHorizontal, 90.0f, moveVertical);

        //Rotate Meeples to look at location of input axis
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);

        //Move Meeples at the movementSpeed
        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        //Start of bobbing
        float waveslice = 0.0f;

        //Set timer for bobbing
        if (Mathf.Abs(moveHorizontal) == 0 && Mathf.Abs(moveVertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            //Increase timer with bobbing speed
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }

        //Get current position
        Vector3 v3T = transform.localPosition;
        if (waveslice != 0)
        {
            //Multiply bobbing wave by the bobbingAmount
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            v3T.y = midpoint + translateChange;
        }
        else
        {
            v3T.y = midpoint;
        }
        transform.localPosition = v3T;
    }
}
