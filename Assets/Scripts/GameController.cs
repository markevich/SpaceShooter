using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount = 1;
	public float spawnWait, startWait, waveWait;

	public Text scoreText, restartText, gameOverText;
	private int _score = 0;

	private bool gameOver, restart = false;

	public void Start(){
		scoreText = scoreText.GetComponent<Text>();
		restartText = restartText.GetComponent<Text>();
		gameOverText = gameOverText.GetComponent<Text>();
		restartText.text = gameOverText.text = "";

		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	private IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true){
			for(int i = 0; i < hazardCount; i++){
				var spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				var hazard = hazards [Random.Range (0, hazards.Length)];
				Instantiate(hazard, spawnPosition, hazard.transform.rotation);
				yield return new WaitForSeconds(spawnWait);
			}

			yield return new WaitForSeconds(waveWait);

			if(gameOver){
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}
		}
	}

	void Update(){
		if(restart)
			if(Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel(Application.loadedLevel);
	}

	private void UpdateScore(){
		scoreText.text = "Score: " + _score;
	}

	public void AddScore(int newScoreValue){
		_score += newScoreValue;
		UpdateScore();
	}

	public void GameOver(){
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
