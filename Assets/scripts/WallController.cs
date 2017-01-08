using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Bullet") {
			GetComponent<AudioSource>().Play();
		}
	}
}
