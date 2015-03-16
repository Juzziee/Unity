using UnityEngine;
using System.Collections;

public class skillsWizard : MonoBehaviour {

	bool FacingDIR;

	public GameObject FireballPrefab;
	GameObject Fireball;
	GameObject Player;


	void Start(){
		Player = GameObject.Find ("Body");
		FireballPrefab = GameObject.Find ("CharacterContainer").GetComponent<skillsWizard> ().FireballPrefab;
	}


	
	// Update is called once per frame
	void Update () {


	
		if (Input.GetButtonDown("Fire1")) {
			FacingDIR = Player.gameObject.GetComponent<Movement>().faceLeft;

				// Attack Right
			if (GameObject.Find ("Body") != null && FacingDIR == false) {
				Fireball = (Instantiate (FireballPrefab, transform.position, transform.rotation)) as GameObject;
				Fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
								
			}
			
			// Attack Left
			if (GameObject.Find ("Body") != null && FacingDIR == true) {
				Fireball = (Instantiate (FireballPrefab, transform.position, transform.rotation)) as GameObject;
				Fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
			}

		}


	}
}
