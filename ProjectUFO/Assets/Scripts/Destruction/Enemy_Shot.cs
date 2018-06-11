using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shot : MonoBehaviour {
    public GameObject prefab;
    public GameObject prefab2;
    public int scoreValue = 10;

	public void GotShot() {

        StartCoroutine (Die ());
	}

	private IEnumerator Die() {
		this.transform.Rotate (0, 0, 0);

		//yield return new WaitForSeconds (1.5f);
        GameObject explosion;
        GameObject brains;

        //creates explosion and brains when triggered
        
        for(int i =0; i < 5; i++){
            explosion = Instantiate(prefab, transform.position, Quaternion.identity);
        }
		
        if(scoreValue != 0)
        {
            for (int i = 0; i < scoreValue; i++)
            {
                brains = Instantiate(prefab2, transform.position, Quaternion.identity);
            }
        }

       

        Destroy(this.gameObject);

        // Increase the score by the enemy's score value.
        ScoreManager.score += scoreValue;

        yield return null; 
	}

}
