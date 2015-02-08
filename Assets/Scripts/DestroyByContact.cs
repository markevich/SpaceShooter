using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue = 1;

	private GameController gameController;

	void Start(){
		var gameControllerInstance = GameObject.FindGameObjectWithTag("GameController");
		if(gameControllerInstance != null)
			gameController = gameControllerInstance.GetComponent<GameController>();

		if(gameController == null)
			Debug.LogError("GameController is not found by DestroyByContact script");
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Boundary")
			return;

		Instantiate(explosion, transform.position, transform.rotation);

		if(other.tag == "Player" || tag == "Player"){
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		gameController.AddScore(scoreValue);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
