using UnityEngine;
using System.Collections;

public class ZombieLifeController : MonoBehaviour {

	[SerializeField] private Rigidbody Rigidbody;
	[SerializeField] private float SinkSpeed;
	[SerializeField] private float SinkDelay;
	[SerializeField] private GameObject DirtParticleSystem;
	[SerializeField] private Transform ZombieCenter;
	[SerializeField] private Animator Animator;
	[SerializeField] private int LifeCount;

	private bool SinkToGround = false;
	public bool Dead = false;

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
			LifeCount--;
			if (LifeCount <= 0) {
				Animator.SetTrigger("Stop");
				Dead = true;
				Rigidbody.useGravity = true;
				Rigidbody.constraints = RigidbodyConstraints.None;
				StartCoroutine(DelaySink());
			}
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
