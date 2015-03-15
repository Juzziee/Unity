using UnityEngine;
using System.Collections;

public class Enemy_Archer : MonoBehaviour
{

		GameObject Archer;				// Archer gameobject.
		public GameObject arrowPrefab;	// Arrow Object.
		float Archer_pos;					// Current position of the bull
		GameObject Player;				// Create player objecty
		float Player_pos;				// Create player position variable 
		public Transform groundCheck; 	// Used for creating grounded 
		float groundRadius = 0.2f;		//
		public LayerMask whatIsGround;	// Marker to show where the ground is
		public bool grounded = false; 	//is the Character grounded?
		public bool visible = false;	// Is the Player in line of site of the mob.
		Vector3 PlayerLoc;				// Contain for player.transform.position
		Vector3 ArrowRot;				//	Arrow rotation to hit player.
		int IgnoreLayer = ((1 << 8) | (1 << 10)); //Ignores all layers with the exception of 8, 10
		public int Damage;						// Damage value for mob.
		int Health;						// Monster health
		float knockForce = 3f;			// Force which the character will be knocked on both axis
		bool ShootRDY = true; 			// Is the monster able to shoot
		float ShootCD = 3;	
		
	
	
	
	
		void Start ()
		{
		
		
				Player = GameObject.Find ("Body");

		
				Health = 10;
		
				// Enemies will not collide with each other
				foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")) {
						Physics2D.IgnoreCollision (GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
				}
		}
	
		void Update ()
		{
				// Set positions container of each object
				if (GameObject.Find ("Body")) {
						Player_pos = Player.transform.position.x;
						ArrowRot = (Player.transform.position - transform.position).normalized;	
						
				}
				Archer_pos = gameObject.transform.position.x;
				
		
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	// Checks for grounded
				Damage = Random.Range (2, 4);
		
				// Update Functions
				LineofSight ();
				CallShoot ();


		}

	
		// Creates the line of site between mob and player
		void LineofSight ()
		{
		
				if (GameObject.Find ("Body")) {
						PlayerLoc = Player.transform.position;
				}
		
				RaycastHit2D hit = Physics2D.Raycast (transform.position, PlayerLoc - transform.position, 40, IgnoreLayer);
				if (hit.collider != null) {
						if (hit.collider.gameObject.tag == "Player") {
								Debug.DrawRay (transform.position, PlayerLoc - transform.position, Color.green);
								visible = true;
						}
						if (hit.collider.gameObject.tag != "Player") {
								Debug.DrawRay (transform.position, PlayerLoc - transform.position, Color.red);
								visible = false;
				
						}
				}
		}

		// Timer for charge cooldown
		IEnumerator ShootTimer (float ShootCD)
		{
				yield return new WaitForSeconds (ShootCD);
				ShootRDY = true;
		
		}

		void EnemyDamage (int amount)
		{
				Health -= amount;
				Debug.Log ("Enemy taken " + amount + " damage");
		
				if (Health <= 0) {
						Destroy (gameObject);
				}
		
		}

		void CallShoot ()
		{
				if (visible == true && ShootRDY) {
						Shoot ();
				}

		}

		void Shoot ()
		{
				GameObject Arrow;

				// Create Arrow
				Arrow = (Instantiate (arrowPrefab, transform.position, Quaternion.LookRotation(ArrowRot))) as GameObject;
				Arrow.GetComponent<Rigidbody2D>().AddForce ((PlayerLoc - transform.position).normalized * 1500);
				ShootRDY = false;
				StartCoroutine(ShootTimer (ShootCD));
		}
	
		//	 Start ReceiveDamage script on collision
		void OnCollisionStay2D (Collision2D coll)
		{			
				if (coll.gameObject.tag == "Player") {
						coll.gameObject.GetComponent<Character> ().ReceiveDamage (Damage);
			
				}
		}
	
		void OnCollisionEnter2D (Collision2D attacker)
		{
				if (attacker.gameObject.tag == "Weapon") {
						EnemyDamage (attacker.gameObject.GetComponent<Weapons> ().Damage);
						GetComponent<Rigidbody2D>().velocity = (knockForce * (transform.position - attacker.gameObject.transform.position));
				}
		}
}
