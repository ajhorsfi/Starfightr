using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	public Vector2 speed = new Vector2(-5f, 0);
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody2D.velocity = speed;
	}
}
