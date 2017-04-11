using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTimer : MonoBehaviour {

    public List<Event> events;
    private List<GameObject> observers;

    void Start()
    {
        observers = new List<GameObject>();
    }

    public void RegisterObserver(GameObject observer)
    {
        observers.Add(observer);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
