using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_destruct : MonoBehaviour {


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "enemy" || col.gameObject.tag == "ground")
        {
            Debug.Log("collision detected!");
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2);
        }

    }
}