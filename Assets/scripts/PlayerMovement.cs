using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private float smooth = 50f;
    Vector3 newPos;



	// Use this for initialization
	void Start () {  
	
	}

	void OnTriggerEnter2D(Collider2D col) 
	{
		if (col.transform.position.z <= transform.position.z) {
			Debug.Log ("ENTER");
		}

	}

	
	// Update is called once per frame
	void Update () {
		// controls
        if (Input.GetAxis("Horizontal") < 0 && transform.position.x > -12)
        {
            newPos = new Vector3(transform.position.x + 0.5f * Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        } else if (Input.GetAxis("Horizontal") > 0 && transform.position.x < 12) {
            newPos = new Vector3(transform.position.x + 0.5f * Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }
	}
}
