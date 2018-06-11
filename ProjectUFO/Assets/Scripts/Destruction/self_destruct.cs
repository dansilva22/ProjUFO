using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_destruct : MonoBehaviour {

    //This script is used to destroy the laser, but can be used to destroy any projectile you shoot.

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