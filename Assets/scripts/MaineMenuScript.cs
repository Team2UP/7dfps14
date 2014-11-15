using UnityEngine;
using System.Collections;

public class MaineMenuScript : MonoBehaviour
{
    private float smooth = 50f;
    Vector3 newPos;

    bool moveLeft = false;
    bool moveRight = false;
    int position = 0;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) && moveLeft == false)
        {
            if (position <= -1)
            {
                moveLeft = false;
            }
            else
            {
                moveLeft = true;
                position--;
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && moveRight == false)
        {
            if (position >= 1)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
                position++;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space) && transform.position.x == 0)
        {
            //Sound.Instance.audio.clip = Sound.Instance.bgm;
            Application.LoadLevel(1);
        }

        if (moveLeft)
        {
            if (transform.position.x <= (8f * position))
            {
                newPos = new Vector3((8f * position), transform.position.y, transform.position.z);
                moveLeft = false;
                transform.position = newPos;
            }
            else
            {
                newPos = new Vector3(transform.position.x + 0.5f * -0.5f, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
            }
        }
        if (moveRight)
        {
            if (transform.position.x >= (8f * position))
            {
                newPos = new Vector3((8f * position), transform.position.y, transform.position.z);
                moveRight = false;
                transform.position = newPos;
            }
            else
            {
                newPos = new Vector3(transform.position.x + 0.5f * 0.5f, transform.position.y, transform.position.z);
                transform.position = Vector3.Lerp(transform.position, newPos, smooth * Time.deltaTime);
            }
        }

    }
}
