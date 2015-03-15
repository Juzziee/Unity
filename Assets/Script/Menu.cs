using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GUIStyle MenuStyle;

	// Use this for initialization
	void OnGUI () {
		if(GUI.Button(new Rect(Screen.width / 2,(Screen.height / 2)-20,100,20), "Start")){
			Application.LoadLevel("Selection");
		}
		if(GUI.Button(new Rect(Screen.width / 2,(Screen.height / 2)+20,100,20), "Exit")){
			Application.Quit();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
