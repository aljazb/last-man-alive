using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	[SerializeField] private int MaxBullets;
	[SerializeField] private float NewBulletTime;
	[SerializeField] private int NumOfBullets;
	[SerializeField] private Transform bulletTransform;
	private float StartTime;

	void Start () {
		StartTime = Time.time;
	}

	void Update () {
		float CurrentTime = Time.time;
		if (CurrentTime - StartTime > NewBulletTime) {
			StartTime = CurrentTime;
			AddBullet();
		}
		if ((Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.Q)) && NumOfBullets > 0) {
			Instantiate(bulletTransform, transform.position, Quaternion.identity);
			DeleteBullet();
		}
	}

	void AddBullet() {
		if (NumOfBullets < MaxBullets) {
			NumOfBullets++;
		}
	}

	void DeleteBullet() {
		if (NumOfBullets > 0) {
			NumOfBullets--;
		}
	}
}
