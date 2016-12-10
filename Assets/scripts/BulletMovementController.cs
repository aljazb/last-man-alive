using UnityEngine;
using System.Collections;

public class BulletMovementController : MonoBehaviour {
	[SerializeField] private int Direction;
	[SerializeField] private float BulletSpeed;

	void Start () {
		Direction = 0; 
	}

	void Update () {
		MoveBullet ();
	}

	void MoveBullet() {
		Debug.Log (Direction);
		switch (Direction) {
			case 0:
				transform.position += Vector3.Normalize(new Vector3(0, 0, 1)) * BulletSpeed * Time.deltaTime; 
				break;
			case 1:
				transform.position += Vector3.Normalize(new Vector3(1, 0, 1)) * BulletSpeed * Time.deltaTime; 
				break;
			case 2:
				transform.position += Vector3.Normalize(new Vector3(1, 0, 0)) * BulletSpeed * Time.deltaTime; 
				break;
			case 3:
				transform.position += Vector3.Normalize(new Vector3(1, 0, -1)) * BulletSpeed * Time.deltaTime; 
				break;
			case 4:
				transform.position += Vector3.Normalize(new Vector3(0, 0, -1)) * BulletSpeed * Time.deltaTime;
				break;
			case 5:
				transform.position += Vector3.Normalize(new Vector3(-1, 0, -1)) * BulletSpeed * Time.deltaTime;
				break;
			case 6:
				transform.position += Vector3.Normalize(new Vector3(-1, 0, 0)) * BulletSpeed * Time.deltaTime;
				break;
			case 7:
				transform.position += Vector3.Normalize(new Vector3(-1, 0, 1)) * BulletSpeed * Time.deltaTime;
				break;
			default:
				break;
		}
	}



}
