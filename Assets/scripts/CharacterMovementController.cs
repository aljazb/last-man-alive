using UnityEngine;
using System.Collections;

public class CharacterMovementController : MonoBehaviour {

	[SerializeField] private float MoveSpeed;
	[SerializeField] private float DiagonalSpeed;
	[SerializeField] private Rigidbody Rigidbody;
	[SerializeField] private Animator Animator;
	public int Direction;

	void Start () {
		Direction = 0;
	}

	void FixedUpdate () {
		float vertMovement = Input.GetAxis("Vertical");
		float horiMovement = Input.GetAxis("Horizontal");

		if (Mathf.Abs(vertMovement) < 0.1f && Mathf.Abs(horiMovement) < 0.1f ) {
			Animator.SetBool("Walk", false);
		} else {
			Animator.SetBool("Walk", true);
		}
		Rigidbody.velocity = Vector3.zero;
		if (vertMovement != 0 && horiMovement != 0) {
			Rigidbody.AddForce(new Vector3(horiMovement * DiagonalSpeed, 0, vertMovement * DiagonalSpeed));
//			transform.position += new Vector3(horiMovement * DiagonalSpeed * Time.deltaTime, 0, vertMovement * DiagonalSpeed * Time.deltaTime);
		} 
		else {
			Rigidbody.AddForce(new Vector3(horiMovement * MoveSpeed, 0, vertMovement * MoveSpeed));
//			transform.position += new Vector3(horiMovement * MoveSpeed * Time.deltaTime, 0, vertMovement * MoveSpeed * Time.deltaTime);
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
