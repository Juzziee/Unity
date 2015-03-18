using UnityEngine;
using System.Collections;

public class FireballExplosion : MonoBehaviour {

	float waitTime = 0.25f;

	void Start () {
		StartCoroutine(explodeFade(waitTime));
	}
	
	IEnumerator explodeFade(float waitTime) {
		yield return new WaitForSeconds (waitTime);
		Destroy (this.gameObject);
		
	}
}
