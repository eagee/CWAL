using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyDotScript : MonoBehaviour {

    public float leftSpawnPoint = -15f;
    public float rightSpawnPoint = 15f;
    
    public float minSize = 0.15f;
    public float maxSize = 0.30f;
    public float minLife = 5.0f;
    public float maxLife = 40.0f;

    private float lifeUsed = 0.0f;
    private float lifeAllowed = 40.0f;

    void setupDot()
    {
        //Vector3 startingPostion = new Vector3(Random.Range(0.3f, 2.5f), Random.Range(7f, 8f), 0.0f);
        //works with cwal proto Vector3 startingPostion = new Vector3(Random.Range(2.15f, 2.2f), Random.Range(9f, 20f), 0.0f);
        Vector3 startingPostion = new Vector3(Random.Range(leftSpawnPoint, rightSpawnPoint), Random.Range(9f, 30f), 0.0f);
        this.transform.position = startingPostion;
        float size = Random.Range(minSize, maxSize);
        Vector3 newScale = new Vector3(size, size, 1.0f);
        gameObject.transform.localScale = newScale;
        gameObject.GetComponent<Rigidbody>().mass = size;
        lifeUsed = 0.0f;
        lifeAllowed = Random.Range(minLife, maxLife);

        //Color currentColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        //currentColor.a = 0f;
        //this.gameObject.GetComponent<SpriteRenderer>().color = currentColor;

    }

    // Use this for initialization
    void Start ()
    {
        setupDot();
    }
    
    // Update is called once per frame
    void Update ()
    {
        lifeUsed += Time.deltaTime;
        if(lifeUsed > lifeAllowed || this.transform.position.y <= -22.0f)
        {
            setupDot();
        }

        //Color currentColor = this.gameObject.GetComponent<SpriteRenderer>().color;
        //if(currentColor.a < 1f)
        //{
        //    currentColor.a += Time.deltaTime / 2f;
        //}
        //this.gameObject.GetComponent<SpriteRenderer>().color = currentColor;

    }
}
