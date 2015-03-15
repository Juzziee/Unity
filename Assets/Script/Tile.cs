using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	float scaleX;
	float scaleY;

	void Start () {
	
		float scaleX = this.gameObject.transform.lossyScale.x / 10;
		float scaleY = this.gameObject.transform.lossyScale.y / 2;

		if (scaleX <= 1) {
			scaleX = 1;
				}
		if (scaleY <= 1) {
			scaleY = 1;
				}

		this.gameObject.GetComponent<Renderer>().material.mainTextureScale = (new Vector3(scaleX, scaleY, 1));
	}
}
