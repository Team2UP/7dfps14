using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {
	private Object bulletRes;

	private bool trigger = false;
    public AudioClip shoot;
	
	void Awake()
	{
		bulletRes = Resources.Load("prefabs/Bullet");
	}
	
	// Use this for initialization
	void Start()
	{

	}

	void Update()
	{

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Instantiate(bulletRes, transform.position, transform.rotation);
            audio.PlayOneShot(shoot);
		}
	}

}
