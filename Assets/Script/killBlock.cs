using UnityEngine;
using System.Collections;

public class killBlock : MonoBehaviour {

	void OnCollisionStay2D(Collision2D coll) {
		Destroy(coll.gameObject);
	}
}
