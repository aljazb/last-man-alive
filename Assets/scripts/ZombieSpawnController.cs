using UnityEngine;
using System.Collections;

public class ZombieSpawnController : MonoBehaviour {
	[SerializeField] private int MaxZombies;
	[SerializeField] private float NewZombieTime;
	[SerializeField] private float NewBigZombieTime;
	[SerializeField] private int NumOfZombies;
	[SerializeField] private int MaxBigZombies;
	[SerializeField] private int NumOfBigZombies;
	[SerializeField] private UnityEngine.UI.Text NumOfBigZombiesText;
	[SerializeField] private UnityEngine.UI.Text NumOfZombiesText;
	private float StartTime;
	private float StartBigTime;

	[SerializeField] private Camera Camera;
	[SerializeField] private GameObject ZombiePrefab;
	[SerializeField] private GameObject BigZombiePrefab;

	void Start () {
		StartTime = Time.time;
		StartBigTime = Time.time;
	}
		
	void Update () {
		if (Input.GetButtonDown("Fire1")  && NumOfZombies > 0) {
			RaycastHit hit;
			Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "ZombieArea") {
				Instantiate(ZombiePrefab, hit.point, ZombiePrefab.transform.rotation);
				DeleteZombie ();
			}
		}
		if (Input.GetButtonDown("Fire2")  && NumOfBigZombies > 0) {
			RaycastHit hit;
			Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "ZombieArea") {
				Instantiate(BigZombiePrefab, hit.point, BigZombiePrefab.transform.rotation);
				DeleteBigZombie ();
			}
		}

		float CurrentTime = Time.time;
		if (CurrentTime - StartTime > NewZombieTime) {
			StartTime = CurrentTime;
			AddZombie();
		}

		if (CurrentTime - StartBigTime > NewBigZombieTime) {
			StartBigTime = CurrentTime;
			AddBigZombie();
		}

		NumOfBigZombiesText.text = NumOfBigZombies.ToString();
		NumOfZombiesText.text = NumOfZombies.ToString();
	}

	void AddZombie() {
		if (NumOfZombies < MaxZombies) {
			NumOfZombies++;
		}
	}

	void AddBigZombie() {
		if (NumOfBigZombies < MaxBigZombies) {
			NumOfBigZombies++;
		}
	}

	void DeleteZombie() {
		if (NumOfZombies > 0) {
			NumOfZombies--;
		}
	}

	void DeleteBigZombie() {
		if (NumOfBigZombies > 0) {
			NumOfBigZombies--;
		}
	}
}
