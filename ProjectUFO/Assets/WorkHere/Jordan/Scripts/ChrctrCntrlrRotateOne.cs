using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrctrCntrlrRotateOne : MonoBehaviour {

    public float movementSpeed = 4;
    public float speedIncrement = 0.08f;
    public float maximumSpeed = 24f;
    private float timer = 0.0f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float midpoint = 0.0f;

    private void Start()
    {
    }

    private void Update()
    {

        movementSpeed += speedIncrement;
        if (movementSpeed >= maximumSpeed) movementSpeed = maximumSpeed;

        float moveHorizontal = Input.GetAxisRaw("Player1_Horizontal");
        float moveVertical = Input.GetAxisRaw("Player1_Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 90.0f, moveVertical);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);


        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        float waveslice = 0.0f;
        if (Mathf.Abs(moveHorizontal) == 0 && Mathf.Abs(moveVertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        Vector3 v3T = transform.localPosition;
        if (waveslice != 0)
        {
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
