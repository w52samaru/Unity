using UnityEngine;
using System.Collections;

public class Behaver : MonoBehaviour {

	private float dx,dy;	//前後左右移動量
	private float dir;		//回転量

	void Start () {
		dx = 0;
		dy = 0;
		dir = 0;
	}
	
	void Update () {
		changeDir ();
	}
	
	private void changeDir(){	//オブジェクトの操作（テスト用）
		float dx, dy;
		if (Input.GetKey (KeyCode.W))
			dx = 0.1F;	//前方へ
		else if (Input.GetKey (KeyCode.S))
			dx = -0.05F;	//後方へ
		else
			dx = 0;	//リセット

		if (Input.GetKey (KeyCode.A))
			dy = 0.05F;	//左へ
		else if (Input.GetKey (KeyCode.D))
			dy = -0.05F;	//右へ
		else
			dy = 0;	//リセット

		if (Input.GetKey (KeyCode.Q)) {
			dir = -1.0F;	//左旋回
		} else if (Input.GetKey (KeyCode.E)) {
			dir = 1.0F;	//右旋回
		} else 
			dir = 0;	//リセット

		gameObject.transform.Translate (dx, 0, dy, Space.Self);	//移動
		gameObject.transform.Rotate (Vector3.up, dir, Space.Self);	//旋回
	}
}
