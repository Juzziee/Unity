using UnityEngine;
using System.Collections;

public class LevelGen : MonoBehaviour {

	public GameObject grassdirtPrefab;
	public GameObject dirtPrefab;
	public GameObject playerPrefab;
	public GameObject doorPrefab;

	Vector3 nextBlock;
	Vector3 prevBlock;
	Vector3 playerSpawn;
	Vector3 dirtFiller;
	Vector3 doorPOS;

	float fillBlock;
	float doorX;
	float doorY;

	// Use this for initialization
	void Start () {
		LoadGen ();
		prevBlock = new Vector3 (0, 0, 0);
		playerSpawn = new Vector3 (0, 20, 0);
	}
	
	// Update is called once per frame
	void LoadGen () {
	
		GameObject Dirt;
		GameObject GrassDirt;
		GameObject Player;
		GameObject Door;

		int i = 1;

		GrassDirt = (Instantiate (grassdirtPrefab, prevBlock, transform.rotation)) as GameObject;
		GrassDirt.name = "GrassDirt 000";

		Player = (Instantiate (playerPrefab, playerSpawn, transform.rotation)) as GameObject;
		Player.name = "Player_Parent";
		Player.transform.position = new Vector3 (0, 20, 0);


		while (i < 30) {
			nextBlock = new Vector3 (i * 10, (Random.Range(2,8)), 0);
			if(prevBlock.y - nextBlock.y > 5 ){
				nextBlock = new Vector3 (i * 10, (Random.Range(2,8)), 0);
			}
			GrassDirt = (Instantiate (grassdirtPrefab, nextBlock, transform.rotation)) as GameObject;
			GrassDirt.name = "GrassDirt";
			prevBlock = nextBlock;
			fillBlock = prevBlock.y;
			while (fillBlock > 0){
				fillBlock = fillBlock - 2;
				dirtFiller = new Vector3 (prevBlock.x, fillBlock, 0);
				Dirt = (Instantiate (dirtPrefab, dirtFiller, transform.rotation)) as GameObject;
				Dirt.name = "Dirt_Filler";
			}
			i++;
		}

		if (i == 30) {
			doorX = prevBlock.x;
			doorY = prevBlock.y + 2.2f;
			doorPOS = new Vector3(doorX, doorY);
			Door = (Instantiate (doorPrefab, doorPOS, transform.rotation)) as GameObject;

		}

	}
}