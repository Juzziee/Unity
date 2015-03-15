using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	public Transform target;
	public float MouseDir;
	GameObject Player;
	Vector3 testPos;

	void Start(){
		Player = GameObject.Find ("Body");
	}
	void Update ()

	{
		if (GameObject.Find ("Body") != null) {
		Vector3 position = transform.position;
		position.x = target.transform.position.x;

			testPos = new Vector3(AveX(), AveY(), -1);
			transform.position = Vector3.Lerp(transform.position, testPos, Time.deltaTime * (float)2);
		}
		Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		MouseDir = mouse.x;

	}

	float AveX(){
		return (Camera.main.ScreenToWorldPoint(Input.mousePosition).x + Player.transform.position.x) * 0.5f;
	}

	float AveY(){
		return (Camera.main.ScreenToWorldPoint(Input.mousePosition).y + Player.transform.position.y) * 0.5f;
	}

}
