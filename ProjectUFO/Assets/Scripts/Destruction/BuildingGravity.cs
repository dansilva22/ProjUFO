using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGravity : MonoBehaviour {
    private Rigidbody rb;
    public float fallForce =3;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        


        if(Physics.Raycast(transform.position,Vector3.down, out hit, 2.0f))
        {
            Debug.DrawRay(transform.position, Vector3.down * hit.distance, Color.green);
            if (rb.isKinematic == false)
                    rb.isKinematic = true;

            if (rb.useGravity == false)
                    rb.useGravity = true;
                       

        }
        else
        {
            if (rb.isKinematic == true)
                rb.isKinematic = false;

            if (rb.useGravity == false)
                rb.useGravity = true;

            rb.AddForce(Vector3.down * fallForce, ForceMode.Impulse);
            //Debug.Log("Bush did 911");
        }
		
	}
}
