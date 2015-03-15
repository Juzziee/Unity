using UnityEngine;
using System.Collections;

public class CameraFol : MonoBehaviour {
		
	Transform target;
	GameObject Player;
	
	void Start(){

	}
	void Update () {

		Player = GameObject.Find ("Body");

		if (GameObject.Find ("Body") != null) {

			transform.position = new Vector3 (Player.gameObject.transform.position.x, 9, -1);	

		}


	}
}
