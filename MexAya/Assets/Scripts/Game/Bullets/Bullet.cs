
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public Vector2 velocity;
	public float speed;
	public float rotation;

	// Use this for initialization
	void Start () {
		transform.rotation = Quaternion.Euler(0, 0, rotation);
	}
	
	// Update is called once per frame
	void Update () {
		//if(transform.position.y > 5f || transform.position.y < -5f || transform.position.x > 8f|| transform.position.x < -8f){
		//	Destroy(gameObject);
		//}
		transform.Translate(velocity*speed*Time.deltaTime);
	}
}
