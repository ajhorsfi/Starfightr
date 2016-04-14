using UnityEngine;
using System.Collections;
using Assets.Game.Scripts.Interfaces;
using Assets.Game.Scripts.States;

public class GameController : MonoBehaviour {
	
	private IStateBase activeState;
	private static GameController instanceRef;
	private GameObject[] pauseObjects;
	
	private PlayerControl playerControl;
	private LifeManager lifeManager;
	
	public bool isPause = false;
	
	void Awake(){
		if(instanceRef == null)
		{
			instanceRef = this;
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
		//Life Meter
		lifeManager = FindObjectOfType<LifeManager>();
		//Pause Stuff
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
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
		Destroy(gameObject);
		Application.LoadLevel("Scene1");
	}
	public void Reload(){
		Application.LoadLevel(Application.loadedLevelName);
	}
	public void Respawn() {
		playerControl.gameObject.SetActive(false);
		lifeManager.SubtractLife();
		playerControl.transform.position = new Vector2(-1.27f, 0.0f);
		Time.timeScale = .5f;
		StartCoroutine(DeathWait(1.0f));
		
		
	}
	IEnumerator DeathWait(float delay){
		yield return new WaitForSeconds(delay);
		playerControl.gameObject.SetActive(true);
		Time.timeScale = 1;
	}
	public void GameOver() {
		
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
