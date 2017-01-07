using UnityEngine;
using System.Collections;

public class MenuZombieSpawnController : MonoBehaviour {

	[SerializeField] private GameObject ZombiePrefab;

	void Start () {
		for (int i = 0; i < 300; i++) {
			Instantiate(ZombiePrefab, transform.position + new Vector3(Random.Range(-200f, 200f), 0, Random.Range(-200f, 200f)), Quaternion.identity);
		}
	}
}
