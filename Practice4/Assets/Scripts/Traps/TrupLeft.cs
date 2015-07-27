using UnityEngine;
using System.Collections;

public class TrupLeft : MonoBehaviour {
	//定数
	private const string TARGETTAG = "Player";	//対象となるオブジェクトのタグ

	//変数
	private int count;	//経過フレーム数

	// Use this for initialization
	void Start () {
		count = 0;	//フレーム数の初期化
	}
	
	// Update is called once per frame
	void Update () {
		count++;
	}
	
	void OnTriggerEnter(Collider collider) {	//衝突したときに実行（コライダコンポーネント）
		if(collider.gameObject.CompareTag(TARGETTAG)) {	//"Enemy"タグのオブジェクトが衝突したとき
			collider.transform.parent.transform.Rotate (Vector3.up, 30, Space.Self);
		}
	}
}
