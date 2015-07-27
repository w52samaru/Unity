using UnityEngine;
using System.Collections;

public class myBlock : MonoBehaviour {
	
	private float deg; //転換する角度
	
	public int count;	//微小な時間に連続して判定してしまわないようにする

	void Start () {
		//初期値
		count = 0;
		deg = 90.0F;
	}
	
	void Update () {
		count++;	//フレーム数
	}

	void OnTriggerEnter(Collider collider) {	//衝突したときに実行（コライダコンポーネント）
		if(collider.gameObject.CompareTag("Enemy")) {	//"Enemy"タグのオブジェクトが衝突したとき
			deg = (Random.value > 0.5) ? 90.0F : -90.0F ;	//ランダムでdegに90か-90かを代入
			collider.GetComponent<myChar>().forceTurn(deg,count);	//回転
		}
	}
}
