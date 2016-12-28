﻿using UnityEngine;
using System.Collections;

public class BombController : MonoBehaviour {

	[SerializeField] private float ExplodeTime;
	[SerializeField] private float Radius;
	[SerializeField] private float Magnitude;
	[SerializeField] private GameObject ExplosionPrefab;

	void Start () {
		StartCoroutine(ExplodeDelay());
	}

	IEnumerator ExplodeDelay() {
		yield return new WaitForSeconds(ExplodeTime);
		Explode();
	}

	private void Explode() {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);
		foreach (Collider hit in hitColliders) {
			if (hit.gameObject.tag == "Zombie") {
				hit.gameObject.GetComponent<ZombieLifeController>().Die();
				Vector3 force = (hit.gameObject.transform.position-transform.position) * Magnitude;
				hit.gameObject.GetComponent<Rigidbody>().AddForce(force);
			} else if (hit.gameObject.tag == "Player") {
				Vector3 force = (hit.gameObject.transform.position-transform.position) * (Magnitude/60f);
				hit.GetComponent<CharacterMovementController>().BombExplode();
				hit.gameObject.GetComponent<Rigidbody>().AddForce(force);
			}
		}
		Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
		Destroy(gameObject);
	}
}