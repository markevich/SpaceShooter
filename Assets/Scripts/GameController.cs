using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount = 1;
	public float spawnWait, startWait, waveWait;

	public void Start(){
		StartCoroutine(SpawnWaves());
	}

	private IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true){
			for(int i = 0; i < hazardCount; i++){
				var spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

				Instantiate(hazard, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);
			}

			yield return new WaitForSeconds(waveWait);
		}
	}
}
