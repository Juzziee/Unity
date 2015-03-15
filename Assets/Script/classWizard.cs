using UnityEngine;
using System.Collections;

public class classWizard : MonoBehaviour {

	float movementSpeed = 8;
	GameObject Player;
	float Moving;
	private Movement movementScript;


	// Use this for initialization
	void Start () {
	
		Movement.moveSpeed = movementSpeed;


	}
	
	// Update is called once per frame
	void Update () {
	
		Debug.Log ("Class movement : " + movementSpeed);
	}
}
