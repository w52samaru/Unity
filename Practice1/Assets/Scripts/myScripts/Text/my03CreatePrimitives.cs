using UnityEngine;
using System.Collections;

public class my03CreatePrimitives : MonoBehaviour {

	// Use this for initialization
	private void Start () {
		// UnityEngine.GameObject
		// public static GameObject CreatePrimitive(PrimitiveTpe type);
		// UnityEngine.PrimitiveType
		// public enum PrimitiveType
		// 生成
		var capsule = GameObject.CreatePrimitive (PrimitiveType.Capsule);
		var cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
		var cylinder = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		var plane = GameObject.CreatePrimitive (PrimitiveType.Plane);
		var sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
		var quad = GameObject.CreatePrimitive (PrimitiveType.Quad);
		// 配置
		capsule.transform.Translate(2, 1, 0);
		cube.transform.Translate (0, 0.5F, 0);
		cylinder.transform.Translate (-2, 1, 0);
		plane.transform.Translate (0, 0.5F, -2);
		sphere.transform.Translate (0, 2, 0);
		quad.transform.Translate (0, 2, 2);
	}
}
