using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
	
	public int playerStartingLives;
	private int playerLives;
	private Text lifeText;
	// Use this for initialization
	void Start () {
		playerLives = playerStartingLives;
		lifeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		lifeText.text = "X " + playerLives;
	
	}
	public void SubtractLife() {
		playerLives--;
		
		if(playerLives == 0){
			//camera.GetComponent<GameController>().GameOver();
		}
	}
	public int GetLives(){
		return playerLives;
	}
}
