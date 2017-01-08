using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	public void PlaySound() {
		GetComponent<AudioSource>().Play();
	}
}
