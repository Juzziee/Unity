using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	bool spawn_rdy = true;		// Flag to stop monsters spawning
 	int mobCount = 0;			// Spawn counter
	int slimeCount = 1;			// Slime Name Counter
	int minotaurCount = 1;		// Minotaur name counter
	int archerCount = 1;		// Archer name counter
	Object EnemySlime;
	Object Minotaur;
	Object Archer;
	Vector3[] SpawnPoints;		// Array of spawn points.
	float RandomSpawn;

	
	public GameObject Enemy_Slime;
	public GameObject Enemy_Bull;
	public GameObject Enemy_Archer;

	void Start(){

		// Pulls all spawn locations into array
		GameObject[] GrassCord = GameObject.FindGameObjectsWithTag("Grass - Enemy Spawn");
		SpawnPoints = new Vector3[GrassCord.Length];
		for(int i = 0; i < GrassCord.Length; i++){
			SpawnPoints[i] = GrassCord[i].transform.position;
		}


	}


	// Spawns a new Enemy_Cube 
	void Update () {

		GameObject SpawnSlime;
		GameObject SpawnBull;
		GameObject SpawnArcher;

		RandomSpawn = Random.Range (0,15);

		if (spawn_rdy && mobCount++ < 15) {
			Debug.Log(SpawnPoints.Length);
			Vector3 SpawnLocation = SpawnPoints[Random.Range (0, SpawnPoints.Length - 1)];

			if(RandomSpawn <=7){
			SpawnSlime = Instantiate (Enemy_Slime, new Vector3 (SpawnLocation.x +1, SpawnLocation.y +1, 0), Quaternion.identity) as GameObject;
				SpawnSlime.name = "Slime "+slimeCount;
				slimeCount++;
			}
			if(RandomSpawn >= 8 && RandomSpawn <= 12){
				SpawnBull = Instantiate (Enemy_Bull, new Vector3 (SpawnLocation.x +1, SpawnLocation.y +1, 0), Quaternion.identity) as GameObject;
				SpawnBull.name = "Minotaur "+minotaurCount;
				minotaurCount++;
			}
			if(RandomSpawn >= 13){
				SpawnArcher = Instantiate (Enemy_Archer, new Vector3 (SpawnLocation.x +1, SpawnLocation.y +1, 0), Quaternion.identity) as GameObject;
				SpawnArcher.name = "Archer "+archerCount;
				archerCount++;
			}
		}
	}
	
}
