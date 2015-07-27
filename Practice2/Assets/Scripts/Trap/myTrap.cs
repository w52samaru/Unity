using UnityEngine;
using System.Collections;
/*
 * "Enemy"タグの付いているオブジェクトの進行方向を変更する
 */
public class myTrap : MonoBehaviour {

	[SerializeField]	//コンポーネントから指定
	private string serDir = null;
	/*	想定文字列
	 * "turn", "left", "right"
	 */

	private float deg; //転換する角度（Awake()で指定）

	private GameObject[] enemy;	//方向転換させる対象

	public int count = 0;	//経過フレーム数　微小時間内複数回実行を防止するため

	void Awake() {	//取得
		if (serDir == "turn")
			deg = 180;
		else if (serDir == "left")
			deg = 90;
		else if (serDir == "right")
			deg = -90;
		else
			Debug.LogError("Error: Set the Tag");
	}

	void Start() {
		enemy = GameObject.FindGameObjectsWithTag ("Enemy");	//タグから対象を取得
	}

	void Update() {
		foreach(GameObject e in enemy) {	// Javaではfor(GameObject e : enemy)と記述される
			if(e.transform.position == gameObject.transform.position){	//対象が同じ座標に到達
				Debug.Log(count);
				e.GetComponent<myChar>().forceTurn(deg, count);
			}
		}
		count++;
	}
}
