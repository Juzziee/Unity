using UnityEngine;
using System.Collections;

public class Enemy_Slime : MonoBehaviour {
	
	float bounceCD; 					// Seconds to wait
	float jumpForce = 150f;				// Jump force of the monster
	float groundRadius = 0.2f;			// 
	float knockForce = 3f;				// Force which the character will be knocked on both axis	
	float waitTime = 1.5f;				// How long the immune ability lasts
	bool grounded = false; 		//is the Character grounded?
	bool bounce_rdy = true; 			// Is moving enabled for this creature.
	bool isImmune = false;				// Character immune to damage after knockback
	GameObject Enemy;					// Enemy object
	GameObject Player;					// Create player object
	GameObject Weapon;					// Weapon Container
	Transform Player_pos;				// Create player position variable 
	public Transform groundCheck; 		// Used for creating grounded 
	public LayerMask whatIsGround;		// Marker to show where the ground is
	public int Damage;					// Monster damage
	public static int Health = 8;		// Monster health


	
	void Start (){




		Player = GameObject.FindGameObjectWithTag("Player");
		Player_pos = Player.transform;
		Weapon = GameObject.FindGameObjectWithTag("Weapon");

		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")){
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
		}
	}

	void Update () {
		Moving();
		bounceCD = Random.Range (2,5);

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	// Checks for grounded		

		Damage = Random.Range(1,3);
	}

	IEnumerator Bounce(float bounceCD) {
		yield return new WaitForSeconds (bounceCD);
		bounce_rdy = true;
	}

	// Timer for monster immunity
	IEnumerator Immune(float waitTime) {
		yield return new WaitForSeconds (waitTime);
		isImmune = false;
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Weapon.GetComponent<Collider2D>(), false);
	}

	void Moving () {
		if(bounce_rdy && Player && grounded){
			GetComponent<Rigidbody2D>().AddForce((Player_pos.position - transform.position).normalized * jumpForce);
			GetComponent<Rigidbody2D>().AddForce(Vector3.up * 275f);
			bounce_rdy = false;
			StartCoroutine(Bounce (bounceCD));
		}
	}

	void EnemyDamage(int amount){

		if (isImmune){
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Weapon.GetComponent<Collider2D>(), true);
			return; 
		}
		Health -= amount;
		
		if( Health <= 0)
		{
			Destroy(gameObject);
		}
		isImmune = true; 
		StartCoroutine(Immune(waitTime));
	}



//	 Start ReceiveDamage script on collision
	void OnCollisionStay2D(Collision2D coll) {			
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<Character>().ReceiveDamage(Damage);
	
			}
		}
	

	void OnCollisionEnter2D(Collision2D attacker) {
		if (attacker.gameObject.tag == "Weapon") {
			EnemyDamage (attacker.gameObject.GetComponent<Weapons>().Damage);
			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			GetComponent<Rigidbody2D>().velocity = (knockForce * (transform.position - attacker.gameObject.transform.position));
		}
	}

}

