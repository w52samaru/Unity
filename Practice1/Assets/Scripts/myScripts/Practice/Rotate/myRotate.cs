using UnityEngine;
using System.Collections;

public class myRotate : MonoBehaviour {
	
	private float count;			//回転量の累積値
	private float dr;				//１フレームあたりの回転量
	private float da;				//回転量の絶対値（drが負の場合に対応）
	private Quaternion tQ;			//目標回転位置
	private Vector3 myAxis;			//回転軸


	void Awake() {		
		myTriger.flag = true;	//回転スクリプト呼び出し中
	}

	void Start () {
		var tGO = new GameObject ();
		tGO.transform.rotation = gameObject.transform .rotation;
		switch(myTriger.dir) {
		case myTriger.rotDir.right:	//右
			myAxis = new Vector3(0,1,0);
			dr = -2;
			tGO.transform.Rotate (myAxis, -90, Space.Self);
			break;
		case myTriger.rotDir.left:	//左
			myAxis = new Vector3(0,1,0);
			dr = 2;
			tGO.transform.Rotate (myAxis, 90, Space.Self);
			break;
		case myTriger.rotDir.up:	//上
			myAxis = new Vector3(1,0,0);
			dr = 2;
			tGO.transform.Rotate (myAxis, 90, Space.Self);
			break;
		case myTriger.rotDir.down:	//下
			myAxis = new Vector3(1,0,0);
			dr = -2;
			tGO.transform.Rotate (myAxis, -90, Space.Self);
			break;
		case myTriger.rotDir.rollR:	//Z軸右回り
			myAxis = new Vector3(0,0,1);
			dr = 2;
			tGO.transform.Rotate (myAxis, 90, Space.Self);
			break;
		case myTriger.rotDir.rollL:	//Z軸左回り
			myAxis = new Vector3(0,0,1);
			dr = -2;
			tGO.transform.Rotate (myAxis, -90, Space.Self);
			break;
		default:	//ありえないはず
			Object.Destroy (tGO);	//不要になったオブジェクトを削除
			myTriger.dir = myTriger.rotDir.none;		//値を初期化
			myTriger.flag = false;	//回転スクリプト呼び出し終了
			Object.Destroy (this);	//このコンポーネントを削除
			break;
		}
		tQ = tGO.transform.rotation;	//後に必要なrotation情報だけを保持
		Object.Destroy (tGO);	//不要になったオブジェクトを削除
		count = 0;
		da = System.Math.Abs(dr);	//絶対値を取得するメソッド
		myTriger.dir = myTriger.rotDir.none;		//値を初期化

		//効果音
		myTriger.SErotate.Play ();
	}

	void Update () {
		if (count >= 90) {	//目標値に到達
			gameObject.transform.rotation = tQ;	//微妙なずれを修正
			myTriger.flag = false;	//回転スクリプト呼び出し終了
			Object.Destroy (this);	//このコンポーネントを削除
		} else {			//未到達・回転
			//回転
			gameObject.transform.Rotate (myAxis, dr, Space.Self);
			count += da;	//回転量の累積値更新
		}
	
	}
}
