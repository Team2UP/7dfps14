using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{

    public float endPos = 100f;
    private bool alive = false;
    private float smooth = 50f;
    private Vector3 newPosition;
    private float stepSize = 1.5f;

    // Use this for initialization
    void Start()
    {
        alive = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Mountain")
        {
            if (col.transform.position.z <= transform.position.z)
            {
                Destroy(gameObject);
            }
        }

        if (col.gameObject.tag == "Enemy")
        {
            if (col.transform.position.z - transform.position.z <= 10 || transform.position.z - col.transform.position.z <= 10)
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
                Highscore.Instance.lastScore += 10;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alive) _Move();
        if (transform.position.z >= endPos)
        {
            alive = false;
            Destroy(gameObject);
        }
    }

    private void _Move()
    {
        newPosition = transform.position;
        newPosition.z += stepSize;
        transform.position = Vector3.Lerp(transform.position, newPosition, smooth * Time.deltaTime);
    }
}
