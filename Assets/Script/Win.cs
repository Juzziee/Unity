using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	GameObject Door; 
	GameObject Player;
	GameObject Door_Continue;
	public Sprite Door_Open;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {

		Door = GameObject.FindGameObjectWithTag ("Door");
		Player = GameObject.FindGameObjectWithTag ("Player");
		Door_Continue = GameObject.Find ("Door_Continue");	

		// Pulls all spawn locations into array
		GameObject[] Enemy = GameObject.FindGameObjectsWithTag("Enemy");

		if (Enemy.Length == 0) {
						Door.GetComponent<SpriteRenderer> ().sprite = Door_Open;
		

						if (Player == true) {
								if (((Door.transform.position.x - Player.transform.position.x) >= -1.5f) && ((Door.transform.position.x - Player.transform.position.x) <= 1.5)) {
										if (Input.GetKey (KeyCode.W)) {
												Application.LoadLevel ("Level_Gen_Test");
										}
								}
						}
				}
	}
}
