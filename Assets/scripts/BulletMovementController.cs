using UnityEngine;
using System.Collections;

public class BulletMovementController : MonoBehaviour {
	[SerializeField] public int Direction;
	[SerializeField] private float BulletSpeed;
	[SerializeField] private GameObject BloodParticleSystem;

	void Update() {
		MoveBullet ();
	}

	void MoveBullet() {
		Vector2 dir = GameController.Dir2Vec(Direction);
		transform.position += Vector3.Normalize(new Vector3(dir.x, 0, dir.y)) * BulletSpeed * Time.deltaTime; 
	}

	void OnCollisionEnter(Collision col) {
		Destroy(gameObject);
		Instantiate(BloodParticleSystem, transform.position, Quaternion.Euler(0,45f*Direction,0));
//		StartCoroutine(DestroyDelay());
	}

//	IEnumerator DestroyDelay() {
//		yield return new WaitForSeconds(0f);
//		Destroy(gameObject);
//	}


}
