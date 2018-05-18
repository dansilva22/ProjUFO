using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrctrCntrlrRotate : MonoBehaviour {

    public float movementSpeed = 2;

    private void Start()
    {
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);


        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
    }
}
