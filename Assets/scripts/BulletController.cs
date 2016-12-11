using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BulletController : MonoBehaviour {
	[SerializeField] private int MaxBullets;
	[SerializeField] private float NewBulletTime;
	[SerializeField] private int NumOfBullets;
	[SerializeField] private Transform bulletTransform;
	[SerializeField] private AudioSource gunshotSound;
	private float StartTime;
	CharacterMovementController Character;

	void Start () {
		StartTime = Time.time;
		Character = GameController.Instance.CharacterMovementController;
	}

	void Update () {
		float CurrentTime = Time.time;
		if (CurrentTime - StartTime > NewBulletTime) {
			StartTime = CurrentTime;
			AddBullet();
		}

		int direction = Character.Direction;
		//Debug.Log ("direction: "+direction);
		if ((Input.GetKeyDown (KeyCode.F) || Input.GetKeyDown (KeyCode.Q)) && NumOfBullets > 0) {
			GameObject bullet = (GameObject) Instantiate(bulletTransform, transform.position, Quaternion.identity);
			BulletMovementController bulletMovementController = bullet.GetComponent<BulletMovementController> ();
			bulletMovementController.Direction = direction;
			gunshotSound.Play();
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
