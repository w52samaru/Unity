using UnityEngine;
using System.Collections;

public class myTower : MonoBehaviour {

	//定数
	private const float DR = 1.0F;	//回転角度

	//一般変数
	GameObject cgo;

	void Start () {
		cgo =  gameObject.transform.FindChild("SciFi-Tower_Rocket Launcher/Tower_Rocket Launcher-R").gameObject;
	}

	void Update () {
		//本体の操作
		if (Input.GetKey (KeyCode.W)) {
			gameObject.transform.Rotate(Vector3.back, DR, Space.Self);
		}
		else if (Input.GetKey (KeyCode.S)) {
			gameObject.transform.Rotate(Vector3.forward, DR/2, Space.Self);
		}
		if (Input.GetKey (KeyCode.A)) {
			gameObject.transform.Rotate(Vector3.down, DR, Space.Self);
		}
		else if (Input.GetKey (KeyCode.D)) {
			gameObject.transform.Rotate(Vector3.up, DR, Space.Self);
		}
		//砲台の操作
		if (Input.GetKey (KeyCode.Q)) {
			cgo.transform.Rotate(Vector3.down, DR, Space.Self);
		}
		else if (Input.GetKey (KeyCode.E)) {
			cgo.transform.Rotate(Vector3.up, DR, Space.Self);
		}
		if (Input.GetKey (KeyCode.R)) {
			cgo.transform.Rotate(Vector3.forward, DR, Space.Self);
		}
		else if (Input.GetKey (KeyCode.F)) {
			cgo.transform.Rotate(Vector3.back, DR, Space.Self);
		}
	}
}
