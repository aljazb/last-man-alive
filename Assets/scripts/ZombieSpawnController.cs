using UnityEngine;
using System.Collections;

public class ZombieSpawnController : MonoBehaviour {

	[SerializeField] private Camera camera;
	[SerializeField] private GameObject zombiePrefab;

	void Start () {
	
	}
		
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "ZombieArea") {
				Instantiate(zombiePrefab, hit.point, zombiePrefab.transform.rotation);
			}
		}
	}
}
