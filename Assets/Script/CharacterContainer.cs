using UnityEngine;
using System.Collections;

public class CharacterContainer : MonoBehaviour {

	public static float charClass;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);
	}

}
