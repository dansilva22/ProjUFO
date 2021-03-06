﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_shooter_v2 : MonoBehaviour
{

    private Camera playerCam;

    public GameObject shootPoint;

    public GameObject lazerExplodey; 

    // Use this for initialization
    void Start()
    {
        playerCam = Camera.main; 

        //Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(shootPoint.transform.position, shootPoint.transform.forward);

        if (Input.GetButtonDown("Jump"))
        {
            //Vector3 point = new Vector3(playerCam.pixelWidth / 2, playerCam.pixelHeight / 2, 0);
            Ray ray = new Ray(shootPoint.transform.position, shootPoint.transform.forward);

            RaycastHit hit;

            //Debug.DrawRay(shootPoint.transform.forward, Vector3.forward);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                Enemy_Shot targett = hitObject.GetComponent<Enemy_Shot>();

                if (targett != null)
                {
                    targett.GotShot();
                }
                else
                {
                    StartCoroutine(ShotGen(hit.point)); // Launch a coroutine in response to a hit!
                }
            }

        }
    }

    private IEnumerator ShotGen(Vector3 pos)
    {
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        //sphere.transform.position = pos;
        GameObject hitExplode = Instantiate(lazerExplodey, pos, shootPoint.transform.rotation);
        yield return new WaitForSeconds(1);

        Destroy(hitExplode);

    }

    void OnGUI()
    {
        int size = 12;
        float posX = playerCam.pixelWidth / 2 - size / 4;
        float posY = playerCam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

}
