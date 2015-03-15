using UnityEngine;
using System.Collections;

public class Ignore : MonoBehaviour {

	GameObject Character;
	// Ignores sword and player collider
	void Start () {
		Character = GameObject.Find ("Body");
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Character.GetComponent<Collider2D>());


	}

}
