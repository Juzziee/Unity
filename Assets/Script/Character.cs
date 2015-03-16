using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	
	public static float Health = 10;				// Character current HP
	public static float maxHealth = 10;	// Character maximum HP
	int amount;							// Place holder for damage taken
	float waitTime = 1.5f;				// How long the immune ability lasts
	bool isImmune = false;				// Character immune to damage after knockback
	float classID;
		
	public void Start(){
		setClass ();
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

	// Set Class
	void setClass(){
		float classID;
		classID = CharacterContainer.charClass;

		if (classID == 1) {
			// Set warrior class
			classWarrior warrior = GameObject.Find("CharacterContainer").GetComponent<classWarrior>();
			warrior.setWarrior();
		}

		if (classID == 2) {
			// Set rogue class
			classRogue rogue = GameObject.Find("CharacterContainer").GetComponent<classRogue>();
			rogue.setRogue();
		}

		if (classID == 3) {
			// Set wizard class
			classWizard wizard = GameObject.Find("CharacterContainer").GetComponent<classWizard>();
			wizard.setWizard();

		}

		if (classID == 4) {
			classDruid druid = GameObject.Find("CharacterContainer").GetComponent<classDruid>();
			druid.setDruid();
		}
	}

}