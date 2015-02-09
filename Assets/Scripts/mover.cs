using UnityEngine;
using System.Collections;

public class mover : MonoBehaviour {
	public float speed = 1;

	void Start(){
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
}
