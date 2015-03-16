using UnityEngine;
using System.Collections;

public class Enemy_Bull : MonoBehaviour {
	
	float chargeCD; 					// Seconds to wait
	public bool charge_rdy; 			// Is moving enabled for this creature.
	GameObject Bull;					// Bull gameobject.
	float Bull_pos;						// Current position of the bull
	GameObject Player;					// Create player objecty
	float Player_pos;					// Create player position variable 
	float chargeForce = 1300f;			// Jump force of the monster
	public Transform groundCheck; 		// Used for creating grounded 
	float groundRadius = 0.2f;			//
	public LayerMask whatIsGround;		// Marker to show where the ground is
	public bool grounded = false; 		//is the Character grounded?
	public bool visible = false;		// Is the Player in line of site of the mob.
	Vector3 PlayerLoc;					// Contain for player.transform.position
	int IgnoreLayer = ((1<<8)|(1<<10)); //Ignores all layers with the exception of 8, 10
	public int Damage;					// Damage value for mob.
	int Health;							// Monster health
	float knockForce = 3f;				// Force which the character will be knocked on both axis	



						
	
	void Start (){


		Player = GameObject.Find("Body");
		charge_rdy = true;

		Health = 20;

		// Enemies will not collide with each other
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
		}
	}
	
	void Update () {
		// Set positions container of each object
		if(GameObject.Find("Body")){
			Player_pos = Player.transform.position.x;
		}
		Bull_pos = gameObject.transform.position.x;

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	// Checks for grounded		
		chargeCD = Random.Range (5,7);
		Damage = Random.Range(2,4);

		// Update Functions
		Moving();
		LineofSight();
	}

	// Timer for charge cooldown
	IEnumerator Charge(float chargeCD) {
		yield return new WaitForSeconds (chargeCD);
		charge_rdy = true;
	
	}

	// Creates the line of sight between mob and player
	void LineofSight(){

		if(GameObject.Find("Body")){
			PlayerLoc = Player.transform.position;
		}

		RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerLoc - transform.position, 25, IgnoreLayer);
		if(hit.collider != null) {
			if(hit.collider.gameObject.tag == "Player"){
				Debug.DrawRay(transform.position, PlayerLoc - transform.position, Color.green);
				visible = true;
			}
			if(hit.collider.gameObject.tag != "Player"){
				Debug.DrawRay(transform.position, PlayerLoc - transform.position, Color.red);
				visible = false;

			}
		}
	}


	void Moving () {

		// Charge Right
		if(charge_rdy && Player_pos >= Bull_pos && visible){
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * chargeForce);	
			StartCoroutine(Charge (chargeCD));
			charge_rdy = false;
		}
		// Charge Left
		if(charge_rdy && Player_pos <= Bull_pos && visible){
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * -chargeForce);
			StartCoroutine(Charge (chargeCD));
			charge_rdy = false;
		}
	}

	// Remove enemy HP
	void EnemyDamage(int amount){
		Health -= amount;
		Debug.Log("Enemy taken " + amount + " damage");
		
		if( Health <= 0)
		{
			Destroy(gameObject);
		}
		
	}

	//	 Deal damage to player
	void OnCollisionStay2D(Collision2D coll) {			
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<Character>().ReceiveDamage(Damage);
			
		}
	}

	// Deal damage to monster
	void OnCollisionEnter2D(Collision2D attacker) {
		if (attacker.gameObject.tag == "Weapon") {
			EnemyDamage (attacker.gameObject.GetComponent<Weapons>().Damage);
			GetComponent<Rigidbody2D>().velocity = (knockForce * (transform.position - attacker.gameObject.transform.position));
		}
	}
}
