using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingInstantiate : MonoBehaviour {

    public GameObject missile;
    public Transform barrelEnd;
    public Transform target;

   public float force = 800f; 

	// Use this for initialization
	void Start () {
        //target = GameObject.FindGameObjectWithTag("reticle");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetButtonDown("Jump"))
        {
            //Rigidbody rocketInstance;
            GameObject bullet = Instantiate(missile, barrelEnd.position, barrelEnd.rotation) as GameObject;

            bullet.GetComponent<Rigidbody>().AddForce(force * barrelEnd.transform.forward);

            //bullet.GetComponent<Rigidbody>().AddForce(force * Input.mousePosition.transform.forward);
            //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

		
	}
}
