using UnityEngine;
using System.Collections;

public class Destruction : MonoBehaviour {

	public Transform explosionPrefab;
	
	void OnCollisionEnter2D(Collision2D collision) {
		
		if (collision.gameObject.tag == "Weapon") {
			Vector3 pos = transform.position;
			Quaternion rot = transform.rotation;
			Instantiate(explosionPrefab, pos, rot);
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
