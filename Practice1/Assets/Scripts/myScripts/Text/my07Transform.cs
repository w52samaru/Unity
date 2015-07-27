using UnityEngine;

public class my07Transform : MonoBehaviour {

	// Use this for initialization
	void Start () {
		/*	System.Object
		 * 		UnityEngine.Object
		 * 			UnityEngine.Component
		 * 				UnityEngine.Transform
		 */
		// public class Transform : Component, IEnumerable	オブジェクトの変形

		// GameObjectクラス	Transformプロパティ
		// public Transform transform { get; }

		// Componentクラス	Transformプロパティ
		// public Tranform tranform { get; }

		// Transformクラス	positionプロパティ
		// public Vector3 position { get; set; }
		var pobj = GameObject.CreatePrimitive (PrimitiveType.Cube);
		var cobj = GameObject.CreatePrimitive (PrimitiveType.Sphere);

		pobj.transform.position = new Vector3 (-1, 0, 0);
		cobj.transform.position = new Vector3 (1, 0, 0);

		// Tranformクラス	positionプロパティ
		// pubilc Vector3 localPosition { get; set; }
		cobj.transform.parent = pobj.transform;

		pobj.transform.position = new Vector3 (1, 1, 0);
		cobj.transform.localPosition = new Vector3 (1, 2, 0);
	}

}
