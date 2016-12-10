using UnityEngine;
using System.Collections;

public class CharacterMovementController : MonoBehaviour {

	[SerializeField] private float moveSpeed;

	void Update () {
		float vertMovement = Input.GetAxis("Vertical");
		float horiMovement = Input.GetAxis("Horizontal");
		transform.position += new Vector3(horiMovement * moveSpeed * Time.deltaTime,0,vertMovement * moveSpeed * Time.deltaTime);
	}
}
