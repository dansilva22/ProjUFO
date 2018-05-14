using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ChangeDirection : MonoBehaviour {

    public string direction;
    // Update is called once per frame
    void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            var btn = EventSystem.current.currentSelectedGameObject;
            if (btn != null)
            {
                Debug.Log("Clicked on : " + btn.name);
                direction = btn.name;
            }
            else
            {
                Debug.Log("currentSelectedGameObject is null");
            }
        }
    }
}
