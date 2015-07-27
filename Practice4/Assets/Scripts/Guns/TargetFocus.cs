using UnityEngine;
using System.Collections;

public class TargetFocus : MonoBehaviour {

	private const float DR = 0.5F;

	private Vector3 Direction;

	// Use this for initialization
	void Start () {
		Direction = Vector3.up;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.rotation.eulerAngles.y > 20F)
			Direction = Vector3.down;
		else if (gameObject.transform.rotation.eulerAngles.y < 5F)
			Direction = Vector3.up;
			gameObject.transform.Rotate(Direction, DR, Space.Self);
		/*
		else if (Random.value < 0.6 )
			gameObject.transform.Translate (Vector3.up/10f, Space.Self);
		else if (Random.value < 0.8 )
			gameObject.transform.Translate (Vector3.down/10f, Space.Self);
		else if (Random.value < 1.0 )
			gameObject.transform.Translate (Vector3.left/10f, Space.Self);
		*/
	}
}
