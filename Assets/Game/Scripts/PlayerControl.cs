using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	private GameController gameManager;
	private LifeManager lifeManager;
	private GameObject[] eFlares;
	private GameObject[] jetSpray;
	
	public Vector2 playerSpeed = new Vector2(8, 8);
	private Vector2 playerMovement;
	public int playerWeapon;
	public int playerLives;
	
	
	private bool wasForward;
	private bool isForward;
	private bool wasBackward;
	private bool isBackward;
	
	public Rigidbody2D weapon1;
	public Rigidbody2D weapon2;
	public Rigidbody2D weapon3;
	
	private Vector3 shotPos;
	private float shotDisplacementX = .05f;
	public float shotSpeed = 3f;
	
	
	// Use this for initialization
	void Start() {
	
		gameManager = GameObject.FindObjectOfType<GameController>();
		lifeManager = GameObject.FindObjectOfType<LifeManager>();
		
		eFlares = GameObject.FindGameObjectsWithTag("EngineFlare");
		jetSpray = GameObject.FindGameObjectsWithTag("JetSpray");
		
		foreach (GameObject g in eFlares) {
			g.SetActive(false);
		}
		foreach (GameObject g in jetSpray) {
			g.SetActive(false);
		}
	}
	void Awake () {
		playerLives = 3;
		playerWeapon = 1;
		wasForward = false;
		wasBackward = false;
		
	}
	
	void Update() {
	
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, -1.24f, 1.24f),
			Mathf.Clamp (transform.position.y, -.58f, .58f),
			transform.position.z);
	}
	
	void FixedUpdate () {
	
		PlayerFire();
		MovementManagement ();
	}
	
	void MovementManagement() {
	
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		PlayerEffects(x);
		playerMovement = new Vector2 (x * playerSpeed.x, y * playerSpeed.y);
		rigidbody2D.velocity = playerMovement;
	}
	
	public void UpgradeWeapon() {
		playerWeapon++;
	}
	public void ResetWeapon() {
		playerWeapon = 1;
	}
	
	void PlayerFire() {
	
		bool isFiring = Input.GetButtonDown("Fire1");
		
		if (isFiring) {
		
			if(playerWeapon == 1) {
				shotPos = transform.position;
				shotPos.x += shotDisplacementX;
				Rigidbody2D weapon1Clone = (Rigidbody2D)Instantiate( weapon1, shotPos, transform.rotation);
				weapon1Clone.velocity = transform.right * shotSpeed;
			}
			if(playerWeapon == 2) {
				shotPos = transform.position;
				shotPos.x += shotDisplacementX;
				Rigidbody2D weapon2Clone = (Rigidbody2D)Instantiate( weapon2, shotPos, transform.rotation);
				weapon2Clone.velocity = transform.right * shotSpeed;
			}
		}
		
	}
	
	
	
	void PlayerEffects(float x) {
		if (x > 0) {
			isForward = true;
		} else {
			isForward = false;
		}
		if (x < 0) {
			isBackward = true;
		} else {
			isBackward = false;
		}
		if (isForward && !wasForward) {
			foreach (GameObject g in eFlares) {
				g.SetActive(true);
			}
		}else if (!isForward && wasForward) {
			foreach (GameObject g in eFlares) {
				g.SetActive(false);
			}
		}
		if (isBackward && !wasBackward){
			foreach (GameObject g in jetSpray) {
				g.SetActive(true);
			}
		}  else if (!isBackward && wasBackward) {
			foreach (GameObject g in jetSpray){
				g.SetActive(false);
			}
		}
		wasForward = isForward;
		wasBackward = isBackward;
	}
	
}
