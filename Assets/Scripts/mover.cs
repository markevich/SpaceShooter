using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
	public float speed = 1;

	void Start(){
		rigidbody.velocity = transform.forward * speed;
	}
}
