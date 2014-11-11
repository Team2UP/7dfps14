using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private float smooth = 50f;
    Vector3 newPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") < 0 && transform.position.x > -12)
        {
            newPos = new Vector3(transform.position.x + 1f * Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        } else if (Input.GetAxis("Horizontal") > 0 && transform.position.x < 12) {
            newPos = new Vector3(transform.position.x + 1f * Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
        }
	}
}
