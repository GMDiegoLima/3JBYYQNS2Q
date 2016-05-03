using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	private bool walkingForward;
	private bool walkingBackward;
	private bool jump;

	public void SetWalkingForward(bool state){
		walkingForward = state;
	}

	public void SetWalkingBackward(bool state){
		walkingBackward = state;
	}

	public void Jump(){
		jump = true;
	}

	void FixedUpdate(){
		if (walkingForward) {
			PlayerMovimentation.main.SetMovement (1);
		} else if (walkingBackward) {
			PlayerMovimentation.main.SetMovement (-1);
		}

		if (jump) {
			PlayerMovimentation.main.TryJump ();
			jump = false;
		}
	}
}
