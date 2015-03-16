using UnityEngine;
using System.Collections;

public class classWizard : MonoBehaviour {

	float movementSpeed = 10;
	float Health = 8;
	GameObject Player;
	float Moving;


	public void setWizard(){

		Player = GameObject.Find ("Body");
		Player.AddComponent<classWizard>();

		Movement.moveSpeed = movementSpeed;
		Character.maxHealth = Health;
		Character.Health = Health;
		Debug.Log ("Wizard attached");

	}
}
