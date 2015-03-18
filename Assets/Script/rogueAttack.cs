using UnityEngine;
using System.Collections;

public class rogueAttack : MonoBehaviour {

	//Physics2D.IgnoreCollision (GetComponent<Collider2D>(), Character.GetComponent<Collider2D>());
	GameObject Dagger;
	bool atkRDY;
	float atkSpeed = 0.20f;


	// Use this for initialization
	void Start () {
		atkRDY = true;
		this.GetComponent<Renderer>().enabled = false;
		this.GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown ("Fire1") && atkRDY) {
			atkRDY = false;
			this.GetComponent<Renderer>().enabled = true;
			this.GetComponent<Collider2D>().enabled = true;
			StartCoroutine(doubleAttack (atkSpeed));
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
}
