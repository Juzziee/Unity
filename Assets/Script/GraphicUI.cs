using UnityEngine;
using System.Collections;

public class GraphicUI : MonoBehaviour {

	public Character CharacterListener;
	public GUIStyle healthBox;

	void Start() {
				CharacterListener = GetComponent<Character> ();
		}

	// Load the GUI health box
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,20), "Health: " + Character.Health + "/" + Character.maxHealth, healthBox);

	}
}