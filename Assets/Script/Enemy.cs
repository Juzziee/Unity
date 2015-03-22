using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public static int Damage;
	public static int enemyHealth;
	public static int maxEnemyHealth;
	float knockForce = 3f;			// Force which the character will be knocked on both axis		



	void EnemyDamage(int amount){
		enemyHealth -= amount;

		if( enemyHealth <= 0)
		{
			Destroy(gameObject);
		}

	}

	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "Weapon") {
			EnemyDamage (coll.gameObject.GetComponent<Weapons>().Damage);
			GetComponent<Rigidbody2D>().velocity = (knockForce * (transform.position - coll.gameObject.transform.position));
		}
	}
}