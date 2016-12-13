using UnityEngine;
using System.Collections;

public class CharacterMovementController : MonoBehaviour {

	[SerializeField] private float MoveSpeed;
	[SerializeField] private float DiagonalSpeed;
	[SerializeField] private Rigidbody Rigidbody;
	[SerializeField] private Animator Animator;
	[SerializeField] private float DiagonalOffsetTime;
	[SerializeField] private float LerpSpeed;
	public int Direction;
	float StopDiagonalWalkTime;
	bool StayDiagonal = false;

	void Start () {
		Direction = 0;
		LerpSpeed = 0;
	}

	void FixedUpdate () {
		float vertMovement = Input.GetAxisRaw("Vertical");
		float horiMovement = Input.GetAxisRaw("Horizontal");

		if (vertMovement == 0 && horiMovement == 0) {
			Animator.SetBool("Walk", false);
		} else {
			Animator.SetBool("Walk", true);
		}

		int prevDirection = Direction;
		Rigidbody.velocity = Vector3.zero;
		if (vertMovement != 0 && horiMovement != 0) {
			Rigidbody.AddForce (new Vector3 (horiMovement * DiagonalSpeed, 0, vertMovement * DiagonalSpeed));
//			transform.position += new Vector3(horiMovement * DiagonalSpeed * Time.deltaTime, 0, vertMovement * DiagonalSpeed * Time.deltaTime);
			SetDirection (vertMovement, horiMovement);
			StopDiagonalWalkTime = Time.time;
		} else if (vertMovement == 0 || horiMovement == 0) {
			if (Time.time - StopDiagonalWalkTime > DiagonalOffsetTime) {
				Rigidbody.AddForce(new Vector3(horiMovement * MoveSpeed, 0, vertMovement * MoveSpeed));
				//transform.position += new Vector3(horiMovement * MoveSpeed * Time.deltaTime, 0, vertMovement * MoveSpeed * Time.deltaTime);
				SetDirection (vertMovement, horiMovement);
			}
		}

		if (prevDirection != Direction) {
			LerpSpeed = 0;
		}

		LerpSpeed += 0.05f;
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, Direction*45, 0), LerpSpeed);
		//SetDirection (vertMovement, horiMovement);
	}

	void SetDirection(float y, float x) {
		if (x == 0 && y == 1) {
			Direction = 0;
		} else if (x == 1 && y == 1) {
			Direction = 1;
		} else if (x == 1 && y == 0) {
			Direction = 2;
		} else if (x == 1 && y == -1) {
			Direction = 3;
		} else if (x == 0 && y == -1) {
			Direction = 4;
		} else if (x == -1 && y == -1) {
			Direction = 5;
		} else if (x == -1 && y == 0) {
			Direction = 6;
		} else if (x == -1 && y == 1) {
			Direction = 7;
		} else {
			//Debug.Log ("vertical:  "+vertMovement);
			//Debug.Log ("horizontal:  "+horiMovement);
		}
	} 
}
