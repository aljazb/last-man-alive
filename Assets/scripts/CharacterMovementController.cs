using UnityEngine;
using System.Collections;

public class CharacterMovementController : MonoBehaviour {

	[SerializeField] private float MoveSpeed;
	[SerializeField] private float DiagonalSpeed;

	void Update () {
		float vertMovement = Input.GetAxis("Vertical");
		float horiMovement = Input.GetAxis("Horizontal");
		if (vertMovement != 0 && horiMovement != 0) {
			transform.position += new Vector3(horiMovement * DiagonalSpeed * Time.deltaTime, 0, vertMovement * DiagonalSpeed * Time.deltaTime);
		} else {
			transform.position += new Vector3(horiMovement * MoveSpeed * Time.deltaTime, 0, vertMovement * MoveSpeed * Time.deltaTime);
		}
	}
}
