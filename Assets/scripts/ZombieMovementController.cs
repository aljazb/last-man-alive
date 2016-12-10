using UnityEngine;
using System.Collections;

public class ZombieMovementController : MonoBehaviour {

	[SerializeField] private float MoveSpeed;
	private Transform characterTransform = null;

	void Start() {
		characterTransform = GameController.Instance.CharacterTransform;
	}

	void Update () {
		transform.position += Vector3.Normalize(characterTransform.position - transform.position) * Time.deltaTime; 
		transform.position = new Vector3(transform.position.x, 0, transform.position.z);
	}
}
