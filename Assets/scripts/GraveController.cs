﻿using UnityEngine;
using System.Collections;

public class GraveController : MonoBehaviour {

	[SerializeField] private int Health;
	[SerializeField] private GameObject GraveDestroyPrefab;
	[SerializeField] private GameObject FloatingBombPrefab;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Bullet") {
			Health--;
			if (Health <= 0) {
				Instantiate(GraveDestroyPrefab, transform.position, GraveDestroyPrefab.transform.rotation);
				Instantiate(FloatingBombPrefab, transform.position, FloatingBombPrefab.transform.rotation);
				Destroy(gameObject);
			}
		}
	}
}