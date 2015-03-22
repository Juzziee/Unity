using UnityEngine;
using System.Collections;

public class Enemy_Bull : MonoBehaviour {

	GameObject Player;				// Player container
	float playerPOS;				// X cord for Player
	float bullPOS;					// X cord for Bull
	float chargeForce = 1300f;		// Force added on charge
	float chargeCD;					// Cool down button each charge
	bool chargeRDY;					// Toggle if the character can charge
	bool Visible;					// Line of sight toggle. 
	int IgnoreLayer = ((1<<8)|(1<<10)); //Ignores all layers with the exception of 8(ground), 10(player)

	void Start() {

		Player = GameObject.Find ("Body");
		chargeRDY = true;
		// Remove collision from other enemy objects.
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
		}
	}

	void Update(){
		// Function calls
		LineofSight ();
		Movement ();


		// Variable Updates
		if (Player) {
			playerPOS = Player.gameObject.transform.position.x;
			bullPOS = this.gameObject.transform.position.x;
		}

		chargeCD = Random.Range (5, 7);
	}

	void Movement(){ 
		// Charging
		if (chargeRDY) {
			// Charge Right
			if (playerPOS >= bullPOS && Visible){
				GetComponent<Rigidbody2D>().AddForce(Vector2.right * chargeForce);
				chargeRDY = false;
				StartCoroutine(Charge (chargeCD));
			}

			// Charge Left
			if(playerPOS <= bullPOS && Visible){
				GetComponent<Rigidbody2D>().AddForce(Vector2.right * -chargeForce);
				chargeRDY = false;
				StartCoroutine(Charge (chargeCD));
			}
		}
	}

	void LineofSight(){
		// Creates the raycast which detects if player is in line of site.

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Player.transform.position - transform.position, 25, IgnoreLayer);
		if(hit.collider != null) {
			if(hit.collider.gameObject.tag == "Player"){
				Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.green);
				Visible = true;
			}
			if(hit.collider.gameObject.tag != "Player"){
				Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.red);
				Visible = false;
				
			}
		}
	}


	IEnumerator Charge(float chargeCD) {
		// Timer for charge cooldown
		yield return new WaitForSeconds (chargeCD);
		chargeRDY = true;
		
	}
}