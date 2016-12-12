using UnityEngine;
using System.Collections;

public class ZombieMovementController : MonoBehaviour {

	[SerializeField] private float MoveSpeed;
	private Transform characterTransform = null;
	[SerializeField] private Rigidbody Rigidbody;

	private bool Dead = false;

	void Start() {
		characterTransform = GameController.Instance.CharacterTransform;
	}

	void FixedUpdate () {
		if (!Dead) {
			Vector3 movement = Vector3.Normalize(characterTransform.position - transform.position) * MoveSpeed;
			Rigidbody.velocity = Vector3.zero;
			Rigidbody.AddForce(movement.x, 0, movement.z); 
		}
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Bullet") {
			Dead = true;
			Rigidbody.useGravity = true;
			Rigidbody.constraints = RigidbodyConstraints.None;
		}
	}
}
