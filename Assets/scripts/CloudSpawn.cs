using UnityEngine;
using System.Collections;

public class CloudSpawn : MonoBehaviour
{
    private Object cloudRes;

    void Awake()
    {
        cloudRes = Resources.Load("prefabs/Cloud");
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
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));

            Instantiate(cloudRes, transform.position, transform.rotation);
        }
    }
}