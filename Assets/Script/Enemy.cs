using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int Damage = 0;
	public int enemyHealth = 5;
	public int maxEnemyHealth = 5;
	float knockForce = 3f;			// Force which the character will be knocked on both axis		

	void Start(){

	}

	void Update(){
		// Damage = Random.Range (1, 4);
	}


	void EnemyDamage(int amount){
		enemyHealth -= amount;
		Debug.Log("Enemy taken " + amount + " damage");
		
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