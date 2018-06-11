using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectMe : MonoBehaviour {

    
    public float flyTime = 1f;

    public GameObject flyToo;

	// Use this for initialization
	void Start () {

        flyToo = GameObject.FindWithTag("Player");


    }

    // Update is called once per frame
    void Update () {

        
        transform.position = Vector3.Lerp(transform.position, flyToo.transform.position, flyTime * Time.deltaTime);



	}

    public void OnCollisionEnter(Collision node)
    {
        if (node.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
