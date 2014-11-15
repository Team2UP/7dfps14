

//This is an error;
// I purposely added this error so you can see it xD
// the only thing left are: 
//    - score
//    - player life
//    - gameover screen (whatever is good here. Up to you. You can either show 
//				"game over press space" and it restarts. or blank scene with those texts) ;)
//    - and music (there are some music in the sounds folder. The one is a soft calm sound, 
//				good for the main menu screen which YOU SHOULD DEFINITELY CHECK OUT! the other is a wind sound. if Possible, can you mix it
//				with the music. But the wind is only heard when the clouds and mountains are moving)
//    - Polish I guess (specially the main menu part). But it's a jam, so it's understandable xD
// 
//
// Those are the only things left I guess. All the other things are done :)


using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private float _smooth = 50f;
    Vector3 newPos;

    private int _playerHealth = 100;
    private Object restartText;
    private bool enableRestart = false;
    private bool _once;

    public AudioClip hurt;

    // Use this for initialization
    void Awake()
    {
        restartText = Resources.Load("prefabs/Press Space");
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.position.z <= transform.position.z)
        {
            audio.PlayOneShot(hurt);
            Destroy(col.gameObject);
            _playerHealth -= 10;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_playerHealth <= 0 && !enableRestart) // player dead 
        {
            Debug.Log("Last Score: " + Highscore.Instance.lastScore);
            Debug.Log("Highscore: " + Highscore.Instance.highScore);
            if (Highscore.Instance.highScore < Highscore.Instance.lastScore) Highscore.Instance.highScore = Highscore.Instance.lastScore;
            Debug.Log("Highscore update: " + Highscore.Instance.highScore);
            Time.timeScale = 0;
            StartCoroutine(_HandleRestart());
        }
        else if (enableRestart) // reload level
        {
            if (Input.anyKey)
            {
                //Sound.Instance.audio.clip = Sound.Instance.intro;
                Application.LoadLevel(0);
            }
        } // controls 
        else if (Input.GetAxis("Horizontal") < 0 && transform.position.x > -12)
        {
            newPos = new Vector3(transform.position.x + 0.5f * Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, _smooth * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") > 0 && transform.position.x < 12)
        {
            newPos = new Vector3(transform.position.x + 0.5f * Input.GetAxis("Horizontal"), transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, _smooth * Time.deltaTime);
        }
    }

    IEnumerator _HandleRestart()
    {
        enableRestart = true;
        if (!_once) Instantiate(restartText, new Vector3(transform.position.x, transform.position.y, transform.position.z + 20), transform.rotation);
        _once = true;
        yield return new WaitForSeconds(0.3f);
    }
}
