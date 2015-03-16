using UnityEngine;
using System.Collections;

public class WeaponAttack : MonoBehaviour {

		Transform target;
		bool FacingDIR;
		GameObject cameralistener;
		GameObject Weapon;
		GameObject Character;
		float CharacterPos;
		GameObject weaponSwing;
		GameObject weaponBlade;
		Transform swordRotation;
		bool changeDirection;
		int currentRotation = 170;
		bool swinging = false;
		bool isSwinging = false;
		Vector3 charDirect;
	
		void Start (){
				Character = GameObject.Find ("Body");
				target = Character.transform;
				weaponSwing = GameObject.Find ("swordAnchor");
				weaponBlade = GameObject.Find ("Sword");
				Physics2D.IgnoreCollision (GetComponent<Collider2D>(), Character.GetComponent<Collider2D>());
				weaponBlade.GetComponent<Renderer>().enabled = false;
				weaponBlade.GetComponent<Collider2D>().enabled = false;
		}

		void Update (){ 
				// Weapon Rotation
				if(GameObject.Find("Body")){
				Vector3 charDirect = Character.gameObject.transform.position;
				CharacterPos = charDirect.x;
		
				Swing ();	
		

				if (Input.GetButtonDown("Fire1") && !isSwinging) {
						FacingDIR = Character.gameObject.GetComponent<Movement>().faceLeft;
						weaponBlade.GetComponent<Renderer>().enabled = true;
						weaponBlade.GetComponent<Collider2D>().enabled = true;
						transform.localEulerAngles = new Vector3 (0, 0, 360);
						swinging = true;
						
			}

				}
				// Attack Right
				if (GameObject.Find ("Body") != null && FacingDIR == false) {
						Vector3 position = transform.position;
						position.x = target.transform.position.x;
						position.y = target.transform.position.y + 0.2f;
						transform.position = position;

				}

				// Attack Left
				if (GameObject.Find ("Body") != null && FacingDIR == true) {
						Vector3 position = transform.position;
						position.x = target.transform.position.x;
						position.y = target.transform.position.y + 0.2f;
						transform.position = position;
				}
	

	
		}

		void Swing (){
				if (swinging == true) {
						isSwinging = true;
						// Attack Right
						if (FacingDIR == false) {
							if (currentRotation >= -100) {
								weaponBlade.transform.localEulerAngles = new Vector3 (0, 0, 0);
								Quaternion newRotation = Quaternion.AngleAxis (currentRotation, Vector3.forward);
								weaponSwing.transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.time * 20000); 
								currentRotation = currentRotation - 6;
										
								} else {
										currentRotation = 0;
										swinging = false;
										weaponBlade.GetComponent<Renderer>().enabled = false;
										weaponBlade.GetComponent<Collider2D>().enabled = false;
										isSwinging = false;
								}
						}

				else if (FacingDIR == true) {
						if (currentRotation <= 100) {
							weaponBlade.transform.localEulerAngles = new Vector3 (0, 180, 0);
							Quaternion newRotation = Quaternion.AngleAxis (currentRotation, Vector3.forward);
							weaponSwing.transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.time * 20000); 
							currentRotation = currentRotation + 6;
										
								} else {
										currentRotation = 0;
										swinging = false;
										weaponBlade.GetComponent<Renderer>().enabled = false;
										weaponBlade.GetComponent<Collider2D>().enabled = false;
										isSwinging = false;
								}
						}
				}
		}
}
