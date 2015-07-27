using UnityEngine;
using System.Collections;

public class myExplosion : MonoBehaviour {

	GameObject fragment1, fragment2, fragment3, fragment4, fragment5, fragment6;

	void Start () {
		//プレハブオブジェクト生成
		GameObject[] fragmentPrefabs = {
			(GameObject)Resources.Load ("Prefabs/Targets/Fragment"),
			(GameObject)Resources.Load ("Prefabs/Targets/Fragment"),
			(GameObject)Resources.Load ("Prefabs/Targets/Fragment"),
			(GameObject)Resources.Load ("Prefabs/Targets/Fragment"),
			(GameObject)Resources.Load ("Prefabs/Targets/Fragment"),
			(GameObject)Resources.Load ("Prefabs/Targets/Fragment"),
		};
		//transform設定
		fragment1 = (GameObject)Instantiate (fragmentPrefabs [0], gameObject.transform.position, gameObject.transform.rotation);
		fragment2 = (GameObject)Instantiate (fragmentPrefabs [1], gameObject.transform.position, gameObject.transform.rotation);
		fragment3 = (GameObject)Instantiate (fragmentPrefabs [2], gameObject.transform.position, gameObject.transform.rotation);
		fragment4 = (GameObject)Instantiate (fragmentPrefabs [3], gameObject.transform.position, gameObject.transform.rotation);
		fragment5 = (GameObject)Instantiate (fragmentPrefabs [4], gameObject.transform.position, gameObject.transform.rotation);
		fragment6 = (GameObject)Instantiate (fragmentPrefabs [5], gameObject.transform.position, gameObject.transform.rotation);
		//削除予約
		Object.Destroy (fragment1, 1.0F);
		Object.Destroy (fragment2, 1.0F);
		Object.Destroy (fragment3, 1.0F);
		Object.Destroy (fragment4, 1.0F);
		Object.Destroy (fragment5, 1.0F);
		Object.Destroy (fragment6, 1.0F);
		Object.Destroy (this, 1.0F);	//このクラス

	}

	void Update () {
		//オブジェクト移動
		fragment1.transform.Translate (Vector3.up * Time.deltaTime, Space.Self);
		fragment2.transform.Translate (Vector3.left * Time.deltaTime, Space.Self);
		fragment3.transform.Translate (Vector3.forward * Time.deltaTime, Space.Self);
		fragment4.transform.Translate (Vector3.down * Time.deltaTime, Space.Self);
		fragment5.transform.Translate (Vector3.right * Time.deltaTime, Space.Self);
		fragment6.transform.Translate (Vector3.back * Time.deltaTime, Space.Self);
	}
}
