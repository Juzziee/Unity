using UnityEngine;
using System.Collections;

public class classRogue : MonoBehaviour {

	float movementSpeed = 12;
	float Health = 10;
	public static float Damage = 10;
	public GameObject weaponPrefab;
	GameObject Weapon;
	GameObject Player;
	Vector3 weaponLocation;

	
	public void setRogue(){
		
		Player = GameObject.Find ("Body");
		Player.AddComponent<classRogue>();
		
		Movement.moveSpeed = movementSpeed;
		Character.maxHealth = Health;
		Character.Health = Health;
		Debug.Log ("Rogue attached");


		weaponLocation = new Vector3 (Player.transform.position.x + 0.75f, Player.transform.position.y, Player.transform.position.z);
		Weapon = (Instantiate (weaponPrefab, weaponLocation, transform.rotation)) as GameObject;
		Weapon.name = "Dagger";
		Parent(Player, Weapon);
	}

	void Parent(GameObject Player, GameObject Weapon){
		Weapon.transform.parent = Player.transform;
	}

}
