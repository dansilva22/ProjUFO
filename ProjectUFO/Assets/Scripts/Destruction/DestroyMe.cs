using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroyThis());

	}
	
	IEnumerator DestroyThis()
    {
        float timer = 4.0f;

        yield return new WaitForSeconds(timer);

        Destroy(gameObject);

       
    }
}
