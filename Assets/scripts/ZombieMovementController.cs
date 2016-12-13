using UnityEngine;
using System.Collections;

public class ZombieMovementController : MonoBehaviour {

	[SerializeField] private float MoveSpeed;
	private Transform characterTransform = null;
	[SerializeField] private Rigidbody Rigidbody;
	[SerializeField] private float SinkSpeed;
	[SerializeField] private float SinkDelay;
	[SerializeField] private GameObject DirtParticleSystem;
	[SerializeField] private Transform ZombieCenter;
	[SerializeField] private Animator Animator;

	private bool Dead = false;
	private bool SinkToGround = false;

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

	void Update() {
		if (SinkToGround) {
			transform.position += Vector3.down * SinkSpeed * Time.deltaTime;
			if (transform.position.y < -3f) {
				Destroy(gameObject);
			}
		}
	}
 
	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Bullet") {
			Animator.SetTrigger("Stop");
			Dead = true;
			Rigidbody.useGravity = true;
			Rigidbody.constraints = RigidbodyConstraints.None;
			StartCoroutine(DelaySink());
		}
	}

	IEnumerator DelaySink() {
		yield return new WaitForSeconds(SinkDelay);
		Instantiate(DirtParticleSystem, ZombieCenter.position, DirtParticleSystem.transform.rotation);
		SinkToGround = true;
		Rigidbody.useGravity = false;
		GetComponent<BoxCollider>().enabled = false;
		GetComponent<CapsuleCollider>().enabled = false;
	}
}
