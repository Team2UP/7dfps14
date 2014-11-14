using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {
	private float smooth = 50f;
	Vector3 newPos;

	// dodging
	bool moveLeft = false;
	bool moveRight = false;
	bool isDodging = false;
	bool isChooseDir = false;
	int position = 0;
	float tempx;

	// movement towards screen
	public float endPos = -8.0f;
	private bool alive = false;
	private Vector3 newPosition;
	private float stepSize = 1.5f;
	private float tick, tick2; // tick = zindex is 90 // tick2 = zindex is 50
	private int zIndex = 1; // zIndex... first the enemy is on z=90 then it will move to z=50 and stop there for a few second

	
	// Use this for initialization
	void Start () {  
		tick = (Time.time * 1000) + 5000; // 5 seconds on z=90
		tick2 = tick + 8000; // another 8 seconds on z=50
	}
	
	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.gameObject.tag == "Mountain") {
			// FOR AI if it detects a mountain
			if (col.transform.position.z <= transform.position.z + 20 && (!isDodging)) {
				if (!isChooseDir) {
					isChooseDir = true;
				
					moveLeft = false;
					moveRight = false;
					// check if he's gonna move left or right
					if (Random.Range (1, 100) < 50) {
						moveLeft = true;
						position--;
					} else {
						moveRight = true;
						position++;
					}
				
					tempx = transform.position.x;
					if (tempx >= 11) {
						moveLeft = true;
						moveRight = false;
					}
					if (tempx <= -11) {
						moveRight = true;
						moveLeft = false;
					}
				}
			}
		}


	}
	
	
	// Update is called once per frame
	void Update () {

		if (!alive) {
			if (tick <= Time.time * 1000) {
				alive = true;
			}

			if (isChooseDir) {
				// move left or right
				if (moveLeft) {
					if (transform.position.x <= tempx - 6) {
						newPos = new Vector3 (tempx - 6, transform.position.y, transform.position.z);
						isChooseDir = false;
						transform.position = newPos;
					} else {
						newPos = new Vector3 (transform.position.x + 0.5f * -0.5f, transform.position.y, transform.position.z);
						transform.position = Vector3.Lerp (transform.position, newPos, smooth * Time.deltaTime);
					}
				}
				if (moveRight) {
					if (transform.position.x >= tempx + 6) {
						newPos = new Vector3 (tempx + 6, transform.position.y, transform.position.z);
						isChooseDir = false;
						transform.position = newPos;
					} else {
						newPos = new Vector3 (transform.position.x + 0.5f * 0.5f, transform.position.y, transform.position.z);
						transform.position = Vector3.Lerp (transform.position, newPos, smooth * Time.deltaTime);
					}
				}
			}
		} else {

			_Move();
			if (transform.position.z <= endPos)
			{
				alive = false;
				Destroy(gameObject);
			}

		}		


	}

	private void _Move()
	{
		newPosition = transform.position;
		newPosition.z -= stepSize;
		transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);

		// check if what zIndex he is in. If it stills 1 it stops moving towards the screen and goes to z=50
		if (transform.position.z <= 50 && zIndex == 1) {
			zIndex = 2;
			alive = false;
			tick = tick2;
		}
	}
}
