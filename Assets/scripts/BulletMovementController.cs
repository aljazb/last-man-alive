using UnityEngine;
using System.Collections;

public class BulletMovementController : MonoBehaviour {
	[SerializeField] public int Direction;
	[SerializeField] private float BulletSpeed;
	[SerializeField] private GameObject BloodParticleSystem;
	[SerializeField] private Rigidbody Rigidbody;

	void FixedUpdate() {
		MoveBullet ();
	}

	void MoveBullet() {
		Vector2 dir = GameController.Dir2Vec(Direction);
		Rigidbody.velocity = Vector3.zero;
		Rigidbody.AddForce(Vector3.Normalize(new Vector3(dir.x, 0, dir.y)) * BulletSpeed);
//		transform.position += Vector3.Normalize(new Vector3(dir.x, 0, dir.y)) * BulletSpeed * Time.deltaTime; 
	}

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Zombie" || col.gameObject.tag == "BigDaddy") {
			Instantiate(BloodParticleSystem, transform.position, Quaternion.Euler(0,45f*Direction,0));
		}
		Destroy(gameObject);
//		StartCoroutine(DestroyDelay());
	}

//	IEnumerator DestroyDelay() {
//		yield return new WaitForSeconds(0f);
//		Destroy(gameObject);
//	}


}
