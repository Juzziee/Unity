using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public int Health = 10;			// Character current HP
	public int maxHealth = 10;		// Character maximum HP
	int amount;						// Place holder for damage taken
	float waitTime = 1.5f;			// How long the immune ability lasts
	bool isImmune = false;			// Character immune to damage after knockback

	public void Start(){

	}
	
	// Timer for player immunity
	IEnumerator Immune(float waitTime) {
		Debug.Log("Is Immune");
		yield return new WaitForSeconds (waitTime);
		isImmune = false;
		Debug.Log("Is no longer immune");
	}


	// Process to take damage
	public void ReceiveDamage(int amount) {
		if (isImmune){
			return; 
		}
		Health -= amount;

		if( Health <= 0)
		{
			ProcessDeath();
			Application.LoadLevel("Retry");
		}
		isImmune = true; 
		StartCoroutine(Immune(waitTime));
	}


	// Character death
	void ProcessDeath()
	{
		Destroy(gameObject);
	}

}