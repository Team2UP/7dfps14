using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour
{

    public float startPos = 90, endPos = -8.0f;
    private bool alive = false;
    private float smooth = 100.0f;
    private Vector3 newPosition;

    // Use this for initialization
    void Start()
    {
        alive = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, startPos);
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
        newPosition.z -= 1;
        transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
    }
}
