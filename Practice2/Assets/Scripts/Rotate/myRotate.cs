using UnityEngine;
using System.Collections;

public class myRotate : MonoBehaviour {

	//定数---------------------------------------------------
	private const float DR = 2.0F;
	//--------------------------------------------------------
	
	private float count;			//回転量の累積値
	private Quaternion tQ;			//目標回転位置
	private Vector3 myAxis;			//回転軸
	
	void Awake() {
		myTriger.flag = true;	//回転スクリプト呼び出し中
	}

	void Start () {
		var tGO = new GameObject ();	//目標
		tGO.transform.rotation = gameObject.transform .rotation;	//現在の回転角度を取得
		switch(myTriger.dir) {
		case myTriger.rotDir.left:	//左
			myAxis = Vector3.up;
			tGO.transform.Rotate (myAxis, 90, Space.Self);
			break;
		case myTriger.rotDir.right:	//右
			myAxis = Vector3.down;	//回転軸
			tGO.transform.Rotate (myAxis, 90, Space.Self);	//目標値設定
			break;
		case myTriger.rotDir.up:	//上
			myAxis = Vector3.right;
			tGO.transform.Rotate (myAxis, 90, Space.Self);
			break;
		case myTriger.rotDir.down:	//下
			myAxis = Vector3.left;
			tGO.transform.Rotate (myAxis, 90, Space.Self);
			break;
		case myTriger.rotDir.rollR:	//Z軸右回り
			myAxis = Vector3.forward;
			tGO.transform.Rotate (myAxis, 90, Space.Self);
			break;
		case myTriger.rotDir.rollL:	//Z軸左回り
			myAxis = Vector3.back;
			tGO.transform.Rotate (myAxis, 90, Space.Self);
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
		myTriger.dir = myTriger.rotDir.none;		//値を初期化

		//効果音
		myTriger.SErotate.Play ();
	}

	void Update () {
		if (count >= 90) {	//目標値に到達
			gameObject.transform.rotation = tQ;	//微妙なずれを修正
			ajustRotation();		//回転角度の微調整
			myTriger.flag = false;	//回転スクリプト呼び出し終了
			Object.Destroy (this);	//このコンポーネントを削除
		} else {			//未到達・回転
			//回転
			gameObject.transform.Rotate (myAxis, DR, Space.Self);
			count += DR;	//回転量の累積値更新
		}
	
	}
	
	private void ajustRotation() {	//回転角度の微調整
		gameObject.transform.rotation = new Quaternion(	//四元数0.1単位で調整
		                                               Mathf.Round(gameObject.transform.rotation.x*10.0F)/10.0F	,
		                                               Mathf.Round(gameObject.transform.rotation.y*10.0F)/10.0F	,
		                                               Mathf.Round(gameObject.transform.rotation.z*10.0F)/10.0F	,
		                                               Mathf.Round(gameObject.transform.rotation.w*10.0F)/10.0F	);
	}
}
