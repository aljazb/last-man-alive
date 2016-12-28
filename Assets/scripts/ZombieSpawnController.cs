using UnityEngine;
using System.Collections;

public class ZombieSpawnController : MonoBehaviour {
	[SerializeField] private int MaxZombies;
	[SerializeField] private float NewZombieTime;
	[SerializeField] private int NumOfZombies;
	[SerializeField] private UnityEngine.UI.Text NumOfZombiesText;
	private float StartTime;

	[SerializeField] private Camera camera;
	[SerializeField] private GameObject zombiePrefab;

	void Start () {
		StartTime = Time.time;
	}
		
	void Update () {
		if (Input.GetButtonDown("Fire1")  && NumOfZombies > 0) {
			RaycastHit hit;
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "ZombieArea") {
				Instantiate(zombiePrefab, hit.point, zombiePrefab.transform.rotation);
				DeleteZombie ();
			}
		}

		float CurrentTime = Time.time;
		if (CurrentTime - StartTime > NewZombieTime) {
			StartTime = CurrentTime;
			AddZombie();
		}

		NumOfZombiesText.text = NumOfZombies.ToString();
	}

	void AddZombie() {
		if (NumOfZombies < MaxZombies) {
			NumOfZombies++;
		}
	}

	void DeleteZombie() {
		if (NumOfZombies > 0) {
			NumOfZombies--;
		}
	}
}
