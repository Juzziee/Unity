using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	GameObject Player;
	public GameObject explosionPrefab;
	GameObject Explosion;
	Vector3 impactPos;
	float waitTime = 0.25f;


	void Start () {
		explosionPrefab = GameObject.Find ("CharacterContainer").GetComponent<Fireball> ().explosionPrefab;
		Player = GameObject.Find ("Body");
		Physics2D.IgnoreCollision (GetComponent<Collider2D>(), Player.GetComponent<Collider2D>());
	}
	
	void OnCollisionEnter2D(Collision2D coll) {	
		impactPos = this.gameObject.transform.position;
		Destroy (gameObject);
		Explosion = (Instantiate (explosionPrefab, impactPos, transform.rotation)) as GameObject;
		Explosion.name = "Explosion";
		StartCoroutine (explodeFade(waitTime));
	}

	IEnumerator explodeFade(float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Destroy (Explosion);

	}
}
