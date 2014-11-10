using UnityEngine;
using System.Collections;

public class CloudSpawn : MonoBehaviour
{
	private Object cloudRes1, cloudRes2, cloudRes3;

    void Awake()
    {
		cloudRes1 = Resources.Load("prefabs/WhiteCloud1");
		cloudRes2 = Resources.Load("prefabs/WhiteCloud2");
		cloudRes3 = Resources.Load("prefabs/WhiteCloud3");
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnCloud());
    }

    IEnumerator SpawnCloud()
    {
        while (true)
        {
			//yield return new WaitForSeconds(Random.Range(0.5f, 2f));
			yield return new WaitForSeconds(Random.Range(1f, 3f));

			int randomCloud = Random.Range(1,4);
			if(randomCloud == 1) Instantiate(cloudRes1, transform.position, transform.rotation);
			else if(randomCloud == 2) Instantiate(cloudRes2, transform.position, transform.rotation);
			else Instantiate(cloudRes3, transform.position, transform.rotation);
        }
    }
}