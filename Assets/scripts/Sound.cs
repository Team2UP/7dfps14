using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
    public static Sound Instance;
    public AudioClip intro;

	// Use this for initialization
	void Awake () {
        if (Instance) DestroyImmediate(gameObject);
        else
        {
            audio.clip = intro;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
	}
}
