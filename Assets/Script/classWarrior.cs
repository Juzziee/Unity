using UnityEngine;
using System.Collections;

public class classWarrior : MonoBehaviour {

	float movementSpeed = 7;
	float Health = 13;
	GameObject Player;
	float Moving;
	
	
	public void setWarrior(){
		
		Player = GameObject.Find ("Body");
		Player.AddComponent<classWarrior>();
		
		Movement.moveSpeed = movementSpeed;
		Character.maxHealth = Health;
		Character.Health = Health;
		Debug.Log ("Warrior attached");
		
	}
}
