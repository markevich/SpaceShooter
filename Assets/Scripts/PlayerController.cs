﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
	public float speed = 1;
	public float tilt = 1;
	
	public Boundary boundary;

	private Vector3 _velocityVector, _clampedPositionVector = Vector3.zero;

	public void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		_velocityVector.x = moveHorizontal;
		_velocityVector.z = moveVertical;

		GetComponent<Rigidbody>().velocity = _velocityVector * speed;

		_clampedPositionVector.x = Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax);
		_clampedPositionVector.z = Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax);

		GetComponent<Rigidbody>().position = _clampedPositionVector;
		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0f, 0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 1f;
	private float nextFire = 0f;

	public void Update(){
		if(Input.GetButton("Fire1") && Time.time > nextFire){
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
			nextFire = Time.time + fireRate;
		}
	}
}
