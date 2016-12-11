using UnityEngine;
using System.Collections;

public class CharacterMovementController : MonoBehaviour {

	[SerializeField] private float MoveSpeed;
	[SerializeField] private float DiagonalSpeed;
	public int Direction;

	void Start () {
		Direction = 0;
	}

	void Update () {
		float vertMovement = Input.GetAxis("Vertical");
		float horiMovement = Input.GetAxis("Horizontal");

		if (vertMovement != 0 && horiMovement != 0) {
			transform.position += new Vector3(horiMovement * DiagonalSpeed * Time.deltaTime, 0, vertMovement * DiagonalSpeed * Time.deltaTime);
		} 
		else {
			transform.position += new Vector3(horiMovement * MoveSpeed * Time.deltaTime, 0, vertMovement * MoveSpeed * Time.deltaTime);
		}

		SetDirection (vertMovement, horiMovement);
	}

	void SetDirection(float vertMovement, float horiMovement) {
		float delay = 0.5f;

		if (vertMovement > delay && horiMovement >= 0 && horiMovement < delay) {
			Direction = 0;
		} else if (vertMovement > delay && horiMovement > delay) {
			Direction = 1;
		} else if (vertMovement >= 0 && vertMovement < delay && horiMovement > delay) {
			Direction = 2;
		} else if (vertMovement < -delay && horiMovement > delay) {
			Direction = 3;
		} else if (vertMovement < -delay && horiMovement >= 0 && horiMovement < delay) {
			Direction = 4;
		} else if (vertMovement < -delay && horiMovement < -delay) {
			Direction = 5;
		} else if (vertMovement >= 0 && vertMovement < delay && horiMovement < -delay) {
			Direction = 6;
		} else if (vertMovement > delay && horiMovement < -delay) {
			Direction = 7;
		} else {
			//Debug.Log ("vertical:  "+vertMovement);
			//Debug.Log ("horizontal:  "+horiMovement);
		}

		transform.rotation = Quaternion.Euler(0, Direction*45, 0);
	} 
}
