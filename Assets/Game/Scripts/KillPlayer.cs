using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {
	
	private GameController gameManager;
	public Transform explosionPrefab;
	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag =="Player") {
			//TODO: Make a killPayer Function in GameController? call Respawn from there.
			Instantiate (explosionPrefab, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
			gameManager.Respawn();
		}
	}
}
