using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

	float screenWidth;
	float screenHeight;

	bool warriorSelect;
	bool rogueSelect;
	bool wizardSelect;
	bool druidSlect;

	public GameObject Player;

	void Start(){
		screenWidth = Screen.width / 100;
		screenHeight = Screen.height / 100;
	}

	void OnGUI () {
		if (GUI.Button (new Rect ((screenWidth * 15), (screenHeight * 10), 100, 20), "Warrior")) {
			// Class ID: 1
			Debug.Log("Warrior");
			warriorSelect = true;
			rogueSelect = false;
			wizardSelect = false;
			druidSlect = false;
			CharacterContainer.charClass = 1;
				}

		if (GUI.Button (new Rect ((screenWidth * 35), (screenHeight * 10), 100, 20), "Rogue")) {
			// Class ID: 2
			Debug.Log("Rogue");
			warriorSelect = false;
			rogueSelect = true;
			wizardSelect = false;
			druidSlect = false;
			CharacterContainer.charClass = 2;
				}

		if (GUI.Button (new Rect ((screenWidth * 55), (screenHeight * 10), 100, 20), "Wizard")) {
			// Class ID: 3
			Debug.Log("Wizard");
			warriorSelect = false;
			rogueSelect = false;
			wizardSelect = true;
			druidSlect = false;
			CharacterContainer.charClass = 3;
				}

		if (GUI.Button (new Rect ((screenWidth * 75), (screenHeight * 10), 100, 20), "Druid")) {
			// Class ID: 4
			Debug.Log("Druid");
			warriorSelect = false;
			rogueSelect = false;
			wizardSelect = false;
			druidSlect = true;
			CharacterContainer.charClass = 4;
				}

		if (GUI.Button (new Rect ((screenWidth * 70), (screenHeight * 90), 100, 20), "Start Game")) {
			Application.LoadLevel ("Platform_Level");
				}

		if (GUI.Button (new Rect ((screenWidth * 30), (screenHeight * 90), 100, 20), "Back")) {
			Application.LoadLevel ("Menu");

				}

	}

}
