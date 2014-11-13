using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	private Object enemyRes;
	
	void Awake()
	{
		enemyRes = Resources.Load("prefabs/Enemy");
	}
	
	// Use this for initialization
	void Start()
	{
		StartCoroutine(SpawnEnemy());
	}
	
	IEnumerator SpawnEnemy()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(5f, 10f));
			Instantiate(enemyRes, transform.position, transform.rotation);
		}
	}
}
