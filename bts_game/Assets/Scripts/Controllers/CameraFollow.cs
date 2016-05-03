using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector3 playerPos;

	private GameObject player;
	[SerializeField]
	[Range(0,0.1f)]
	private float lerpTime;
	[SerializeField]
	private bool followYAxys;
	[SerializeField]
	[Range(0,5f)]
	private float heightCorrection;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void FixedUpdate(){
		if (player == null)
			return;

		if (followYAxys)
			playerPos = new Vector3 (player.transform.position.x, player.transform.position.y + heightCorrection, transform.position.z);
		else
			playerPos = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);

		transform.position = Vector3.Lerp (transform.position, playerPos, lerpTime);
	}
}
