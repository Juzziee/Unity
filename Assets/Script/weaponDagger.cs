using UnityEngine;
using System.Collections;

public class weaponDagger : MonoBehaviour {

	GameObject Player;
	bool atkRDY;
	bool FacingDIR;
	float atkSpeed = 0.20f;
	Vector3 daggerPos;
	
	
	// Use this for initialization
	void Start () {
		atkRDY = true;
		this.GetComponent<Renderer>().enabled = false;
		this.GetComponent<Collider2D>().enabled = false;
		Player = GameObject.Find ("Body");
	}
	
	// Update is called once per frame
	void Update () {

	
		if (Input.GetButtonDown ("Fire1") && atkRDY) {
			FacingDIR = Player.gameObject.GetComponent<Movement> ().faceLeft;
			atkRDY = false;
			this.GetComponent<Renderer> ().enabled = true;
			this.GetComponent<Collider2D> ().enabled = true;
			StartCoroutine (doubleAttack (atkSpeed));
			
			// Attack Right
			if (GameObject.Find ("Body") != null && FacingDIR == false) {
				daggerPos = new Vector3((Player.transform.position.x + 0.75f), Player.transform.position.y, Player.transform.position.z);
				this.transform.position = daggerPos;
				
			}
			
			// Attack Left
			if (GameObject.Find ("Body") != null && FacingDIR == true) {
				daggerPos = new Vector3((Player.transform.position.x - 0.75f), Player.transform.position.y, Player.transform.position.z);
				this.transform.position = daggerPos;
			}
		}

	}

	IEnumerator doubleAttack(float atkSpeed) {
		yield return new WaitForSeconds (atkSpeed);
		this.GetComponent<Renderer>().enabled = false;
		this.GetComponent<Collider2D>().enabled = false;
		yield return new WaitForSeconds (atkSpeed);
		this.GetComponent<Renderer>().enabled = true;
		this.GetComponent<Collider2D>().enabled = true;
		yield return new WaitForSeconds (atkSpeed);
		this.GetComponent<Renderer>().enabled = false;
		this.GetComponent<Collider2D>().enabled = false;
		atkRDY = true;
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
		//	col.gameObject.GetComponent<Enemy>().enemyHealth;

		}
	}

}

