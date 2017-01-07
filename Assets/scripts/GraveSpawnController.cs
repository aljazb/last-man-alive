using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraveSpawnController : MonoBehaviour {

	[SerializeField] private GameObject GravePrefab = null;
	[SerializeField] private int MinGraveCount;
	[SerializeField] private int MaxGraveCount;
	[SerializeField] private Vector2 MaxDistFromCenter;
	[SerializeField] private float MinGraveDist;
	[SerializeField] private Transform CharacterPos;

	List<Vector2> GravePositions;

	void Start () {
		int graveCount = Random.Range(MinGraveCount, MaxGraveCount);
		GravePositions = new List<Vector2>();
		GravePositions.Add(new Vector2(CharacterPos.position.x, CharacterPos.position.z));
		for (int i = 0; i < graveCount; i++) {
			Vector2 gravePos = FindSpawnPos();	
			GravePositions.Add(gravePos);
			GameObject Grave = (GameObject)Instantiate(GravePrefab, new Vector3(gravePos.x, transform.position.y, gravePos.y), Quaternion.Euler(0, Random.Range(0, 360f), 0));
			Grave.transform.parent = transform;
		}
	}

	Vector2 FindSpawnPos() {
		Vector2 gravePos = new Vector2(Random.Range(-MaxDistFromCenter.x, MaxDistFromCenter.x), Random.Range(-MaxDistFromCenter.y, MaxDistFromCenter.y));
		foreach (Vector2 pos in GravePositions) {
			if (Vector2.Distance(gravePos, pos) < MinGraveDist)
				return FindSpawnPos();
		}
		return gravePos;
	}
}
