using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour
{

    public int lastScore;
    public int highScore;
    public static Highscore Instance;
    TextMesh highscoreText;
    MeshRenderer highscoreTextMesh;
    MeshRenderer scoreTextChild;
    TextMesh scoreTextMesh;


    void Awake()
    {

        if (Instance) DestroyImmediate(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            highscoreText = GetComponent<TextMesh>();
            highscoreTextMesh = highscoreText.GetComponent<MeshRenderer>();
            scoreTextChild = transform.GetChild(0).GetComponent<MeshRenderer>();
            scoreTextMesh = scoreTextChild.GetComponent<TextMesh>();
        }

    }
    // Use this for initialization
    void Start()
    {

        lastScore = 0;
        highScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        highscoreText.text = "Highscore: " + highScore;
        if (Application.loadedLevel == 0)
        {
            highscoreTextMesh.enabled = true;
            scoreTextChild.enabled = false;
        }
        else
        {
            highscoreTextMesh.enabled = false;
            scoreTextChild.enabled = true;
            scoreTextMesh.text = "Score: " + lastScore;
        }
    }

    void OnGUI()
    {

    }
}
