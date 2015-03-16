using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{ 
	public static float moveSpeed;		// Character movement speed.
	public bool grounded = false; 		//is the Character grounded?
	public Transform groundCheck; 		// Used for creating grounded 
	float groundRadius = 0.2f;			//
	public LayerMask whatIsGround;		// Marker to show where the ground is
	float jumpForce = 15f;				// Force for vertical velocity (jumping)
	float knockForce = 8f;				// Force which the character will be knocked on both axis		
	float travelTime = 0.1f;			// Timer to set how often the timer will check for grounded to reset velocity
	float dashCD = 2;					// Dash cooldown timer
	public float doubleJump_rdy = 1;	// Double jump limit
	bool movement = true;				// Disables movement during knockbacks
	bool dash_rdy = true;				// Is dash able to be used.
	float dashForce = 1000f; 			// Power of dash
	public bool faceLeft;				// Monitors character facing direction


	void Start(){
	

	}


	void Update(){

		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);	// Checks for grounded		

			if (movement) {
			if (Input.GetKey (KeyCode.A)) {
				transform.position += Vector3.left * moveSpeed * Time.deltaTime;
				faceLeft = true;
			}
			if (Input.GetKey (KeyCode.D)) {
				transform.position += Vector3.right * moveSpeed * Time.deltaTime;
				faceLeft = false;
			}
			}

		if (Input.GetButtonDown("Dash Left") && dash_rdy) {
			GetComponent<Rigidbody2D>().AddForce (Vector3.left * dashForce);
			StartCoroutine (knockBack (travelTime));
			dash_rdy = false;
			movement = false;
			StartCoroutine (dash (dashCD));
		}
		if (Input.GetButtonDown("Dash Right") && dash_rdy) {
			GetComponent<Rigidbody2D>().AddForce (Vector3.right * dashForce);
			StartCoroutine (knockBack (travelTime));
			dash_rdy = false;
			movement = false;
			StartCoroutine (dash (dashCD));
		}
		
	
		if (grounded && Input.GetButtonDown ("Jump")) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (0, jumpForce);
		}

		if (!grounded && Input.GetButtonDown ("Jump") && doubleJump_rdy > 0) {
			GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpForce);
			doubleJump_rdy = 0;
			} 
			else if (grounded == true) {		
				doubleJump_rdy = 1;
			}

	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			GetComponent<Rigidbody2D>().velocity = (knockForce * (transform.position - coll.gameObject.transform.position));
			StartCoroutine (knockBack (travelTime));
			movement = false;
			dash_rdy = false;

		}
	
	}

	IEnumerator knockBack(float travelTime) {
		yield return new WaitForSeconds (travelTime);
		movement = true;
		dash_rdy = true;
		if (!grounded) {
			StartCoroutine (knockBack (travelTime));
			movement = false;
			dash_rdy = false;
		}
		if (grounded){
			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}
	}

	IEnumerator dash(float dashCD) {
		yield return new WaitForSeconds (dashCD);
			dash_rdy = true;

		}
	}
