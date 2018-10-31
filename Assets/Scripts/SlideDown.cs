using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDown : MonoBehaviour {

    private float speed = 0f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(0, -1) * speed * Time.deltaTime);
	}

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

}
