using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovimentation : MonoBehaviour {

	public static PlayerMovimentation main;
	private Rigidbody body;
	private bool running;
	private int currentJumpMultiply;

	[Header("Walk")]
	[SerializeField]
	private float walkForce;
	[SerializeField]
	private float runningForce;

	[Header("Jump")]
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	[Tooltip("Quantity of air jumps.")]
	private int airJumpMultiply;
	[SerializeField]
	private float airJumpForce;

	[Header("Options")]
	[SerializeField]
	[Tooltip("Turn the player direction when move forward and backward")]
	private bool turnDirection;

	void Awake(){
		body = gameObject.GetComponent<Rigidbody>();
		if (body == null)
			Debug.LogError ("Can't find RigidBody on gameObject");

		main = this;
	}

	void Move(float direction){
		if (direction == 0)
			return;
		
		if (turnDirection)
			transform.localScale = new Vector3 (direction, transform.localScale.y, transform.localScale.z);

		float velocity = direction;
		velocity *= (running)? runningForce : walkForce;

		body.AddForce ((Vector3.right * velocity) * Time.deltaTime, ForceMode.Acceleration);
	}

	void OnCollisionEnter(Collision other){
		currentJumpMultiply = airJumpMultiply;
	}

	/// <summary>
	/// Set the state of player movimentation.
	/// </summary>
	public void SetRunning(bool state){
		running = state;
	}

	/// <summary>
	/// This function need to be called every frame to set the direction of player movimentation.
	/// <param name="direction"> Value need to be -1, 0 or 1.</param>
	public void SetMovement(int direction){
		Move (direction);
	}

	/// <summary>
	/// Tries the jump.
	/// </summary>
	public void TryJump(){
		if (Physics.Raycast (transform.position, -(Vector3.up), 0.55f)) {
			body.velocity = new Vector3 (body.velocity.x, 0, body.velocity.z);
			body.AddForce ((Vector3.up * jumpForce) * Time.deltaTime, ForceMode.Impulse);
		} else if (currentJumpMultiply > 0) {
			currentJumpMultiply--;
			body.velocity = new Vector3 (body.velocity.x, 0, body.velocity.z);
			body.AddForce ((Vector3.up * airJumpForce) * Time.deltaTime, ForceMode.Impulse);
		}
	}
}
