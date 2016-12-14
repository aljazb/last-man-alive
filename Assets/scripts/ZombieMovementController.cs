using UnityEngine;
using System.Collections;

public class ZombieMovementController : MonoBehaviour {

	[SerializeField] private float MoveSpeed;
	private Transform characterTransform = null;
	[SerializeField] private Rigidbody Rigidbody;
	[SerializeField] private ZombieLifeController ZombieLifeController;

	void Start() {
		characterTransform = GameController.Instance.CharacterTransform;
	}

	void FixedUpdate () {
		if (!ZombieLifeController.Dead) {
			Vector3 movement = Vector3.Normalize(characterTransform.position - transform.position) * MoveSpeed;
			Rigidbody.velocity = Vector3.zero;
			Rigidbody.AddForce(movement.x, 0, movement.z); 
		}
	}

	void Update() {
		float charX = characterTransform.position.x;
		float charY = characterTransform.position.z;
		float zombieX = transform.position.x;
		float zombieY = transform.position.z;

		Vector2 norm_vector = new Vector2(charX - zombieX, charY - zombieY).normalized;

		float angle = Mathf.Atan2(norm_vector.x, norm_vector.y) * Mathf.Rad2Deg;

		if (!ZombieLifeController.Dead) {
			transform.eulerAngles = new Vector3 (0, angle, 0);
		}
	}
}
