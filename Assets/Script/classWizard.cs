using UnityEngine;
using System.Collections;

public class classWizard : MonoBehaviour {

	float movementSpeed = 10;
	float Health = 8;
	float Moving;

	GameObject Player;


	public void setWizard(){

		Player = GameObject.Find ("Body");
		Player.AddComponent<classWizard>();
		Player.AddComponent<skillsWizard> ();

		Movement.moveSpeed = movementSpeed;
		Character.maxHealth = Health;
		Character.Health = Health;
		Debug.Log ("Wizard attached");

	}

}
