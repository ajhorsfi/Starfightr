using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
	
	private static LifeManager lifeManagerInstance;
	private GameController gameManager;
	public int playerStartingLives;
	private int playerLives;
	private Text lifeText;
	public float safeTimer = 1.0f;
	private float safeEndtime = 0;
	private bool safeFlag = false;
	// Use this for initialization
	void Start () {
		playerLives = playerStartingLives;
		lifeText = GetComponent<Text>();
	}
	
	void Awake() {
		if(lifeManagerInstance == null)
		{
			lifeManagerInstance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			DestroyImmediate(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		lifeText.text = "X " + playerLives;
		
		if (safeFlag){
			if (Time.time >= safeEndtime){
				safeFlag = false;
			}
		}
	}
	public void setGameManager(GameController instance) {
		gameManager = instance;
		if(gameManager == null)
			Debug.LogError("game manager not connected!");
	}
	public void SubtractLife() {
		safeFlag = true;
		safeEndtime = Time.time + safeTimer;
		playerLives--;
		if(playerLives == 0){
			gameManager.GameOver();
		}
	}
	public int GetLives(){
		return playerLives;
	}
	public bool isSafe(){
		return safeFlag;
	}
}
