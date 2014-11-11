using UnityEngine;
using System.Collections;

public class MountainSpawn : MonoBehaviour {

	private Object mountainRes1, mountainRes2;
	
	void Awake()
	{
		mountainRes1 = Resources.Load("prefabs/Mountain1");
		mountainRes2 = Resources.Load("prefabs/Mountain2");
	}
	
	// Use this for initialization
	void Start()
	{
		StartCoroutine(SpawnMountain());
	}
	
	IEnumerator SpawnMountain()
	{
		while (true)
		{
			//yield return new WaitForSeconds(Random.Range(0.5f, 2f));
			yield return new WaitForSeconds(Random.Range(1.5f, 3f));
			
			int randomMountain = Random.Range(1,3);
			if(randomMountain == 1) Instantiate(mountainRes1, transform.position, transform.rotation);
			else Instantiate(mountainRes2, transform.position, transform.rotation);
		}
	}
}
