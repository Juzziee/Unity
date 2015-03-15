using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

	public int Damage;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Damage = Random.Range (2, 4);
	}
}
