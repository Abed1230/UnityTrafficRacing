using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScrollController : MonoBehaviour {

    private float speed = 0f;
    private Vector2 offset;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        offset = new Vector2(0, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
	}

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
