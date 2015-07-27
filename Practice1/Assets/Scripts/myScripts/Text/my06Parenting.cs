using UnityEngine;
using System.Collections;

public class my06Parenting : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var cDiv1 = new GameObject ("First Carrier Division");
		var akagi = new GameObject ("Akagi");
		var kaga = new GameObject ("Kaga");

		var dDiv7 = new GameObject ("Destroyer Division 7");
		var akebono = new GameObject ("Akebono");
		var ushio = new GameObject ("Ushio");
		
		//親子関係
		// Transformクラス	parentプロパティ
		// public Transform parent { get; set; }
		akagi.transform.parent = cDiv1.transform;
		kaga.transform.parent = cDiv1.transform;

		dDiv7.transform.parent = cDiv1.transform;
		akebono.transform.parent = dDiv7.transform;
		ushio.transform.parent = dDiv7.transform;

		//検索
		var cube1 = GameObject.Find ("/Cube");
		var cube2 = GameObject.Find ("/Container/Cube");
		cube1.name = "RootCube";
		cube2.name = "ChildCube";
	}
}
