using UnityEngine;
using System.Collections;

public class PowerUpBehaviour : MonoBehaviour {
	private float nextChange;
	public float directionInterval = 1.0f;
	private float direction = 1.0f;
	public float movementSpeed = 1.0f;
	private Vector2 upgradeMovement;
	// Use this for initialization
	void Start () {
		upgradeMovement = new Vector2(-1*movementSpeed, direction*movementSpeed);
		rigidbody2D.velocity = upgradeMovement;
		direction *= -1;
		nextChange = Time.time + directionInterval;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time >= nextChange){
			upgradeMovement.y = direction * movementSpeed;
			rigidbody2D.velocity = upgradeMovement;
			direction *= -1;
			nextChange += directionInterval;
		}
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Destroy(gameObject);
			coll.gameObject.GetComponent<PlayerControl>().UpgradeWeapon();
		}
	}
}
