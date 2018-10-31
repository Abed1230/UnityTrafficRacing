using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private GameObject gameController;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private float horizontalMoveSpeed;
    [SerializeField]
    private float minHorizontalPosition;
    [SerializeField]
    private float maxHorizontalPosition;

    private Vector2 position;

	// Use this for initialization
	void Start () {
        position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        position.x += Input.acceleration.x * horizontalMoveSpeed * Time.deltaTime;
        //position.x += Input.GetAxis("Horizontal") * horizontalMoveSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, minHorizontalPosition, maxHorizontalPosition);
        transform.position = position;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy Car"))
        {
            audioSource.PlayOneShot(audioSource.clip);
            Destroy(gameObject);
            gameController.GetComponent<GameController>().GameOver(); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Coin"))
        {
            Destroy(collision.gameObject);
            gameController.GetComponent<GameController>().IncreaseCoins();
        }
    }

}
