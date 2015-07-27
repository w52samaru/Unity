using UnityEngine;

public class my08Translate : MonoBehaviour {
	private GameObject _cube;
	private Vector3 _direction;
	void Start () {
		// Tranformクラス	Translate()メソッド
		// public void Translate(Vector3 translation);
		// public void Translate(Vector3 translation, Space relativeTo);
		// public void Translate(Vector3 translation, Transform relativeTo);
		// public void Translate(float x, float, y, float z);
		// public void Translate(float x, float, y, float z, Space relativeTo);
		// public void Translate(float x, float, y, float z, Transform relativeTo);

		// UnityEngine.Space列挙型
		// public enum Space

		_cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		_direction = Vector3.right;
	}

	void Update () {
		if (_cube.transform.position.x > 3)
			_direction = Vector3.left;
		if (_cube.transform.position.x < -3)
			_direction = Vector3.right;
		_cube.transform.Translate (_direction * 0.1F);
	}
}
