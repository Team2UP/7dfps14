using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {
	private float smooth = 50f;
	Vector3 newPos;
	
	bool moveLeft = false;
	bool moveRight = false;
	bool isDodging = false;
	bool isChooseDir = false;
	int position = 0;
	float tempx;
	
	
	// Use this for initialization
	void Start () {  
		
	}
	
	void OnTriggerEnter2D(Collider2D col) 
	{
		// FOR AI
		if (col.transform.position.z <= transform.position.z + 20 && (!isDodging)) {
			if (!isChooseDir) {
				isChooseDir = true;
				
				moveLeft = false;
				moveRight = false;
				if (Random.Range (1, 100) < 50) {
					moveLeft = true;
					position--;
				} else {
					moveRight = true;
					position++;
				}
				
				tempx = transform.position.x;
				if(tempx >= 12){
					moveLeft = true;
					moveRight = false;
				}
				if(tempx <= -12){
					moveRight = true;
					moveLeft = false;
				}
			}
		}
		//Debug.Log (isDodging);
	}
	
	
	// Update is called once per frame
	void Update () {
		if (isChooseDir) {
			if (moveLeft) {
				if(transform.position.x <= tempx - 6){
					newPos = new Vector3(tempx - 6, transform.position.y, transform.position.z);
					isChooseDir = false;
					transform.position = newPos;
				} else {
					newPos = new Vector3 (transform.position.x + 1f * -0.5f, transform.position.y, transform.position.z);
					transform.position = Vector3.Lerp (transform.position, newPos, smooth * Time.deltaTime);
				}
			}
			if (moveRight) {
				if(transform.position.x >= tempx + 6){
					newPos = new Vector3(tempx + 6, transform.position.y, transform.position.z);
					isChooseDir = false;
					transform.position = newPos;
				} else {
					newPos = new Vector3 (transform.position.x + 1f * 0.5f, transform.position.y, transform.position.z);
					transform.position = Vector3.Lerp (transform.position, newPos, smooth * Time.deltaTime);
				}
			}
		}

	}
}
