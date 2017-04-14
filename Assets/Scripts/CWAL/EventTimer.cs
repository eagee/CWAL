using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTimer : MonoBehaviour {

    public List<Event> events;
    private List<GameObject> observers;

    public float StartingWaterLevel = -12f;
    public float EndingWaterLevel = 2f;
    public float WaterLevelSpeed = 2f;

    private float m_waterLevel;

    public float GetWaterLevel()
    {
        return m_waterLevel;
    }

    void Start()
    {
        observers = new List<GameObject>();
        m_waterLevel = StartingWaterLevel;
    }

    public void RegisterObserver(GameObject observer)
    {
        observers.Add(observer);
    }

    // Update is called once per frame
    void Update () {
        // Gradually increase our water level
        if(m_waterLevel < EndingWaterLevel)
        {
            m_waterLevel += Time.deltaTime * WaterLevelSpeed;
        }
        
    }
}
