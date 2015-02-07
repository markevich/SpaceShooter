using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;

	public void Start(){
		SpawnWaves();
	}

	private void SpawnWaves(){
		var spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

		Instantiate(hazard, spawnPosition, Quaternion.identity);
	}
}
