
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
        if (transform.position.y > 4f || transform.position.y < -2f || transform.position.x > 12f || transform.position.x < -11f)
        {
            Destroy(gameObject);
        }
        transform.Translate(velocity*speed*Time.deltaTime);
	}
}
