using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 2f;
	private float nextFire = 0f;
	
	public void Update(){
		if(Time.time > nextFire){
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play();
			nextFire = Time.time + fireRate;
		}
	}
}
