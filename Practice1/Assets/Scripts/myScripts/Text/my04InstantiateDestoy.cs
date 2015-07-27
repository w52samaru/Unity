using UnityEngine;
using System.Collections;

public class my04InstantiateDestoy : MonoBehaviour {

	// Use this for initialization
	private void Start () {
		// [TypeInferenceRule(TypeInferenceRules.TypeOfFirstArgument)]
		// public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);
		var pos = new Vector3 (2, 0, 0);		//座標
		var rot = new Vector3 (0, 45, 0);		//向き
		var original = GameObject.CreatePrimitive (PrimitiveType.Cube);	//オブジェクト
		var copy = Object.Instantiate (original, pos, Quaternion.Euler (rot));	//複製
		// GameObject型に変換できない場合はnull
		// Quaternionは向きを表現する型
		
		// public static void Destroy(Object obj);	すぐにobjを削除する
		// public static void Destroy(Object obj, float t);	t[s]後に削除する
		Object.Destroy (original, 1.0f);
		Object.Destroy (copy, 2.0f);
		Object.Destroy (this);	// スクリプト自身を削除

		//組み合わせ
		Object.Destroy (GameObject.CreatePrimitive (PrimitiveType.Capsule), 1.5f);

		/*
		 * Unityのオブジェクトは意図して削除させなければシーンに残り続けてしまう
		 */
	}
}
