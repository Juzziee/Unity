using UnityEngine;
using System.Collections;

public class classDruid : MonoBehaviour {

	float movementSpeed = 12;
	float Health = 8;
	GameObject Player;
	float Moving;
	
	
	public void setDruid(){
		
		Player = GameObject.Find ("Body");
		Player.AddComponent<classDruid>();
		
		Movement.moveSpeed = movementSpeed;
		Character.maxHealth = Health;
		Character.Health = Health;
		Debug.Log ("Druid attached");
		
	}
}
