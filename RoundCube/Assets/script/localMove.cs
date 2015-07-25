using UnityEngine;
using System.Collections;

public class localMove : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	void Move () {
		if (gameObject.transform.position.x < 10) {
			
			iTween.MoveTo (gameObject, iTween.Hash ("x", (gameObject.transform.position.x) + 1, "islocal", true, "oncomplete", "Move"));
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
