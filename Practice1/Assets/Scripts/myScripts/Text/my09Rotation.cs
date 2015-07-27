using UnityEngine;

public class my09Rotation : MonoBehaviour {

	private GameObject pcube;
	private GameObject ccube;

	// Use this for initialization
	void Start () {
		// Transformクラス	ratationプロパティ
		// public Quaternion rotation { get; set; }
		pcube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		ccube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		pcube.name = "World Rotation";
		ccube.name = "Local Rotation";
		ccube.transform.parent = pcube.transform;
		pcube.transform.position = new Vector3 (-2, 0, 0);
		ccube.transform.position = new Vector3 (2, 0, 0);

		pcube.transform.rotation = Quaternion.Euler (45, 0, 0);
		ccube.transform.localRotation = Quaternion.Euler (0, 45, 0);
		// Quaternion.Euler()はオイラー角を四元数に変換する
	}
	
	// Update is called once per frame
	void Update () {
		// Transformクラス Rotate()メソッド
		// public void Rotate(Vector3 eulerAngles);
		// public void Rotate(Vector3 axis, float angle);
		// public void Rotate(Vector3 eulerAngles, Space relativeTo);
		// public void Rotate(float xAngle, float yAngle, float zAngle);
		// public void Rotate(Vector3 axis, float angle, Space relativeTo);
		// public void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo);
		pcube.transform.Rotate (Vector3.up, 2, Space.World);
		ccube.transform.Rotate (Vector3.right, 3, Space.Self);
		// Vector3 axisは回転軸
		// float angleは1フレーム回転量・
		// Space relativeToはワールド座標軸か自分自身軸か
	}
}
