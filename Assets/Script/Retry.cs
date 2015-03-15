using UnityEngine;
using System.Collections;

public class Retry : MonoBehaviour {

	public GUIStyle MenuStyle;


	// Use this for initialization
	void OnGUI () {

		GUI.Box(new Rect(250,50,100,20), "You are dead", MenuStyle);

		if(GUI.Button(new Rect(Screen.width / 2,(Screen.height / 2)-20,100,20), "Retry")){
			Application.LoadLevel("Platform_Level");
		}
		if(GUI.Button(new Rect(Screen.width / 2,(Screen.height / 2)+20,100,20), "Exit")){
			Application.Quit();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
