using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount = 1;
	public float spawnWait, startWait, waveWait;

	public Text scoreText, restartText, gameOverText, levelText;
	private int currentHazardCount;
	private int _score = 0;
	private int _level = 1;

	private bool gameOver, restart = false;

	public void Start(){
		scoreText = scoreText.GetComponent<Text>();
		restartText = restartText.GetComponent<Text>();
		gameOverText = gameOverText.GetComponent<Text>();
		levelText = levelText.GetComponent<Text>();
		restartText.text = gameOverText.text = "";

		currentHazardCount = hazardCount;
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	private IEnumerator SpawnWaves(){
		yield return new WaitForSeconds(startWait);
		while(true){
			for(int i = 0; i < currentHazardCount; i++){
				var spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				var hazard = hazards [Random.Range (0, hazards.Length)];
				Instantiate(hazard, spawnPosition, hazard.transform.rotation);
				yield return new WaitForSeconds(spawnWait);
			}

			currentHazardCount += 3;
			if(gameOver){
				restartText.text = "Press 'R' to restart";
				restart = true;
				break;
			}

			_level += 1;
			levelText.text = "Level: " + _level;
			yield return new WaitForSeconds(waveWait);
		}
	}

	void Update(){
		if(restart)
			if(Input.GetKeyDown(KeyCode.R)){
				Application.LoadLevel(Application.loadedLevel);
				_level = 1;
				levelText.text = "Level: 1";
			}
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
