using UnityEngine;
using System.Collections;

public class ExplosionBehaviour : MonoBehaviour {

	public float destroyTime = 2.0f;
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, destroyTime);
	}
}
