using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
	
	private GameController gameController;
	public Transform explosionPrefab;
	// Use this for initialization
	void Start () {
		gameController = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag =="Player") {
			gameController.Respawn();
			Instantiate (explosionPrefab, transform.position, transform.rotation);
		}
	}
}
