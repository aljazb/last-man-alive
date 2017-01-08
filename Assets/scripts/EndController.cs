using UnityEngine;
using System.Collections;

public class EndController : MonoBehaviour {

	[SerializeField] private Animator CameraAnimator = null;
	[SerializeField] private AudioSource PlayerDieSound;

	void OnTriggerEnter(Collider col) {
		if (col.gameObject.tag == "Player") {
			PlayerDieSound.Play();
			CameraAnimator.SetTrigger("End");
			if (!GetComponent<AudioSource>().isPlaying)
				GetComponent<AudioSource>().Play();
		}
	}
}
