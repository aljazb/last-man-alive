using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

	[SerializeField] private float DestroyTime;

	void Start () {
		StartCoroutine(DestroyDelay());
	}

	IEnumerator DestroyDelay() {
		yield return new WaitForSeconds(DestroyTime);
		Destroy(gameObject);
	}

}
