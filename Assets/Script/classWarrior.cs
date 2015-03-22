using UnityEngine;
using System.Collections;

public class classWarrior : MonoBehaviour {

	float movementSpeed = 7;
	float Health = 13;
	public static float Damage = 8;
	public GameObject weaponPrefab;
	GameObject Weapon;
	GameObject Player;

	
	
	public void setWarrior(){
		
		Player = GameObject.Find ("Body");
		Player.AddComponent<classWarrior>();
		
		Movement.moveSpeed = movementSpeed;
		Character.maxHealth = Health;
		Character.Health = Health;
		Debug.Log ("Warrior attached");

		Weapon = (Instantiate (weaponPrefab, Player.transform.position, transform.rotation)) as GameObject;
		Weapon.name = "swordAnchor";
		Parent(Player, Weapon);

	}

	void Parent(GameObject Player, GameObject Weapon){
		Weapon.transform.parent = Player.transform;
	}
}
