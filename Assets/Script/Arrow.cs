using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

	public int Damage = 2;
	int ArrowLifeTime = 6;


	void Start () {
	
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy")) {
						Physics2D.IgnoreCollision (GetComponent<Collider2D>(), obj.GetComponent<Collider2D>());
				}


		StartCoroutine(ArrowLife (ArrowLifeTime));

	}


	//	 Start ReceiveDamage script on collision
	void OnCollisionEnter2D(Collision2D coll) {		
		if (coll.gameObject.tag == "Player") {
			Debug.Log("hit");
			coll.gameObject.GetComponent<Character>().ReceiveDamage(Damage);
			Destroy(gameObject);
		}
		Destroy (gameObject);
	}

	// Timer for charge cooldown
	IEnumerator ArrowLife(float ArrowLifeTime) {
		yield return new WaitForSeconds (ArrowLifeTime);
		Destroy (gameObject);
		
	}

}


