using UnityEngine;
using System.Collections;

public class ShotBehaviour : MonoBehaviour {
	public float destroyTime = 2.0f;
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject, destroyTime);
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player"){
		
		}else
			Destroy(gameObject);
	}
	
}
