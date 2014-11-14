

//This is an error;
// I purposely added this error so you can see it xD
// the only thing left are: 
//    - score
//    - player life
//    - gameover screen (whatever is good here. Up to you. You can either show 
//				"game over press space" and it restarts. or blank scene with those texts) ;)
//    - and music (there are some music in the sounds folder. The one is a soft calm sound, 
//				good for the main menu screen which YOU SHOULD DEFINITELY CHECK OUT! the other is a wind sound. if Possible, can you mix it
//				with the music. But the wind is only heard when the clouds and mountains are moving)
//    - Polish I guess (specially the main menu part). But it's a jam, so it's understandable xD
// 
//
// Those are the only things left I guess. All the other things are done :)


using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private float _smooth = 50f;
    Vector3 newPos;

    private int _playerHealth = 100;

	// Use this for initialization
	void Start () {  
	
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collision with " + col.name);
		if (col.transform.position.z >= transform.position.z) {
            Debug.Log("hit");
            _playerHealth -= 10;
            if (_playerHealth <= 0) {
                Debug.Log("DEAD - Game Over");
                Time.timeScale = 0;
            }
		}

	}

	
	// Update is called once per frame
	void Update () {
		// controls
        if (Input.GetAxis("Horizontal") < 0 && transform.position.x > -12)
        {
            newPos = new Vector3(transform.position.x + 0.5f * Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, _smooth * Time.deltaTime);
        } else if (Input.GetAxis("Horizontal") > 0 && transform.position.x < 12) {
            newPos = new Vector3(transform.position.x + 0.5f * Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, _smooth * Time.deltaTime);
        }
	}
}
