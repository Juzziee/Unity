using UnityEngine;
using System.Collections;

public class Selection : MonoBehaviour {

	float screenWidth;
	float screenHeight;
	bool mageSelect;
	public GameObject Player;

	void Start(){
		screenWidth = Screen.width / 100;
		screenHeight = Screen.height / 100;
	}

	void OnGUI () {
		if (GUI.Button (new Rect ((screenWidth * 15), (screenHeight * 10), 100, 20), "Warrior")) {
			Debug.Log("Warrior");
				}

		if (GUI.Button (new Rect ((screenWidth * 35), (screenHeight * 10), 100, 20), "Rogue")) {
			Debug.Log("Rogue");
				}

		if (GUI.Button (new Rect ((screenWidth * 55), (screenHeight * 10), 100, 20), "Wizard")) {
			Debug.Log("Wizard");
			mageSelect = true;
				}

		if (GUI.Button (new Rect ((screenWidth * 75), (screenHeight * 10), 100, 20), "Druid")) {
			Debug.Log("Druid");
				}

		if (GUI.Button (new Rect ((screenWidth * 70), (screenHeight * 90), 100, 20), "Start Game")) {
			Application.LoadLevel ("Platform_Level");
				}

		if (GUI.Button (new Rect ((screenWidth * 30), (screenHeight * 90), 100, 20), "Back")) {
			Application.LoadLevel ("Menu");

			//Player = GameObject.Find ("Body");

			if(mageSelect == true){
				Player.gameObject.AddComponent<classWizard>();
			}
				}

	}

}
