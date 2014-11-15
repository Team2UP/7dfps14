using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {
	private Object bulletRes;

	private bool trigger = false;
    public AudioClip shoot;
    private bool isShooting = false;
	
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

		if (Input.GetKeyDown (KeyCode.Space) && !isShooting) 
		{
            StartCoroutine(Shoot());
		}
	}

    IEnumerator Shoot() {
        isShooting = true;
        Instantiate(bulletRes, transform.position, transform.rotation);
        audio.PlayOneShot(shoot);
        yield return new WaitForSeconds(0.3f);
        isShooting = false;
    }
}
