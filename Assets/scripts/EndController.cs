using UnityEngine;
using System.Collections;

public class EndController : MonoBehaviour {

	[SerializeField] private Animator CameraAnimator = null;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			CameraAnimator.SetTrigger("End");
			if (!GetComponent<AudioSource>().isPlaying)
				GetComponent<AudioSource>().Play();
		}
	}
}
