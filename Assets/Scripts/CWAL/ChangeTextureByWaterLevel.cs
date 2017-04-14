using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextureByWaterLevel : MonoBehaviour {

    public EventTimer eventTimer;
    public string ParameterToChange = "_BottomLimit";

    // Use this for initialization
    void Start () {
        if(eventTimer == null)
            eventTimer = FindObjectOfType<EventTimer>();
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.SetFloat(ParameterToChange, eventTimer.GetWaterLevel());

    }
}

