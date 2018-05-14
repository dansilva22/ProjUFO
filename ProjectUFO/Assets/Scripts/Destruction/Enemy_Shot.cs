using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shot : MonoBehaviour {
    public GameObject prefab;

	public void GotShot() {

        StartCoroutine (Die ());
	}

	private IEnumerator Die() {
		this.transform.Rotate (0, 0, 0);

		//yield return new WaitForSeconds (1.5f);
        GameObject explosion;

        
        for(int i =0; i < 5; i++){
            explosion = Instantiate(prefab, transform.position, Quaternion.identity);
        }
		Destroy (this.gameObject);

        yield return null; 
	}

}
