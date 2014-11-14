using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour
{

    public float endPos = -1.0f;
    private bool alive = false;
	private float smooth = 50f;
    private Vector3 newPosition;
    private float stepSize = 0.8f;

    // Use this for initialization
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) _Move();
        if (transform.position.z <= endPos)
        {
            alive = false;
            Destroy(gameObject);
        }
    }

    private void _Move()
    {
        newPosition = transform.position;
        newPosition.z -= stepSize;
        transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
    }
}
