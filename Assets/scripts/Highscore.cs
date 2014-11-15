using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour
{

    public int lastScore;
    public int highScore;
    public static Highscore _selfRef;

    GUIStyle centeredStyle;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _selfRef = this;
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

    }

    void OnGUI()
    {
        centeredStyle = GUI.skin.GetStyle("Label");
        centeredStyle.alignment = TextAnchor.UpperRight;
        GUI.Label(new Rect((Screen.width), 100, 200, 100), "Score: " + (int)lastScore, centeredStyle);
        centeredStyle.alignment = TextAnchor.UpperLeft;
        GUI.Label(new Rect((Screen.width), 100, 200, 100), "<color=black>Highest Score: " + (int)highScore + "</color>", centeredStyle);

    }
}
