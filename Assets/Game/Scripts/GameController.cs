using UnityEngine;
using System.Collections;
using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.States;

public class GameController : MonoBehaviour {
	
	private IStateBase activeState;
	private static GameController gameControllerInstance;
	private GameObject[] pauseObjects;
	private GameObject[] gameOverObjects;
	
	private PlayerControl playerControl;
	private LifeManager lifeManager;
	public float respawnSlowDuration = 1.0f;
	
	public bool isPause = false;
	public bool isGameOver = false;
	
	void Awake(){
		if(gameControllerInstance == null)
		{
			gameControllerInstance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			DestroyImmediate(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		activeState = new BeginState(this);
		
		//Player
		playerControl = FindObjectOfType<PlayerControl>();
		playerControl.setGameManager(this);
		//Life Meter
		lifeManager = FindObjectOfType<LifeManager>();
		lifeManager.setGameManager(this);
		//Pause Stuff
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
		//Game Over Stuff
		gameOverObjects = GameObject.FindGameObjectsWithTag("ShowOnGameOver");
	}
	
	// Update is called once per frame
	void Update () {
	
		if (activeState != null) {
			activeState.StateUpdate();
		}			
		if (Input.GetKeyUp(KeyCode.Escape)) {
			PauseControl();
		}
	}
	
	void OnGui() {
		if (activeState != null){
			activeState.ShowIt();
		}
		if (isPause)
		{
		
		}
	}
	public void SwitchState(IStateBase newState){
		activeState = newState;
	}
	public void Restart() {
		Destroy(playerControl.gameObject);
		Destroy(lifeManager.gameObject);
		Destroy(gameObject);
		Application.LoadLevel("Scene1");
	}
	public void Reload(){
		Application.LoadLevel(Application.loadedLevelName);
	}
	public void Respawn() {
		//TODO: hash out the respawn so its fluent
		if (!lifeManager.isSafe()){
			playerControl.gameObject.SetActive(false);
			lifeManager.SubtractLife();
			playerControl.transform.position = new Vector2(-1.27f, 0.0f);
			Time.timeScale = .5f;
			StartCoroutine(DeathWait(respawnSlowDuration));
			
		}
		
	}
	IEnumerator DeathWait(float delay){
		yield return new WaitForSeconds(delay);
		if (!isGameOver) {
			playerControl.gameObject.SetActive(true);
			Time.timeScale = 1.0f;
		}
	}
	public void GameOver() {
		isGameOver = true;
		Time.timeScale = 0;
		Debug.Log ("Game Over! "+ Time.timeScale );
		//TODO: finish this so it actually works
	}
	public void PauseControl()
	{
		isPause = !isPause;
		if (isPause) {
			Time.timeScale = 0;
			showPaused();
		}
		else {
			Time.timeScale = 1;
			hidePaused();
		}
	}
	void hidePaused(){
		foreach(GameObject g in pauseObjects) {
			g.SetActive(false);
		}
	}
	void showPaused() {
		foreach(GameObject g in pauseObjects) {
			g.SetActive(true);
		}
	}
}
