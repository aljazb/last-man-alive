using UnityEngine;
using System.Collections;

public class DirtController : MonoBehaviour {
	[SerializeField] private GameObject DirtParticleSystem;

	void ShowDirt() {
		Instantiate(DirtParticleSystem, transform.GetChild(0).transform.position, DirtParticleSystem.transform.rotation);
	}
}
