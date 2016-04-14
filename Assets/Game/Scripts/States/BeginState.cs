using UnityEngine;
using Assets.Game.Scripts.Interfaces;

namespace Assets.Game.Scripts.States
{
	public class BeginState : IStateBase {
	
		private GameController stateManager = null;
		public BeginState (GameController reference) {
			stateManager = reference;
			if(Application.loadedLevelName != "Scene1")
				Application.LoadLevel("Scene1");
		}
		public void StateUpdate(){
			/*if (Input.anyKeyDown)
				stateManager.SwitchState (new PlayState1 (manager));*/
		}
		public void ShowIt(){
			Debug.Log ("In BeginState");
		}
	}
}