using UnityEngine;
using System.Collections;

public class classRogue : MonoBehaviour {

	float movementSpeed = 12;
	float Health = 10;
	GameObject Player;
	float Moving;
	
	
	public void setRogue(){
		
		Player = GameObject.Find ("Body");
		Player.AddComponent<classRogue>();
		
		Movement.moveSpeed = movementSpeed;
		Character.maxHealth = Health;
		Character.Health = Health;
		Debug.Log ("Rogue attached");
		
	}
}
