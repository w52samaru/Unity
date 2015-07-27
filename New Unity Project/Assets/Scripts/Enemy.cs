using UnityEngine;
using System.Collections;

public class Enemy : Token {
	private Load load = new Load();
	// Use this for initialization
	void Start () {
		// サイズを設定
		SetSize(SpriteWidth / 2, SpriteHeight / 2);
		// ランダムな方向に移動する
		// 方向をランダムに決める
//		float dir = Random.Range(0, 359);
		// 方向は水平右
		float dir = 0;
		// 速さは2
		float spd = 1;
		SetVelocity(dir, spd);
	
	}
	
	// Update is called once per frame
	void Update () {
		// カメラの左下座標を取得
		Vector2 min = GetWorldMin ();
		// カメラの右上座標を取得する
		Vector2 max = GetWorldMax ();
		/*
		if (X < min.x || max.x < X) {
			// 画面外に出たので、X移動量を反転する
			VX *= -1;
			// 画面内に移動する
			ClampScreen ();
		}
		if (Y < min.y || max.y < Y) {
			// 画面外に出たので、Y移動量を反転する
			VY *= -1;
			// 画面内に移動する
			ClampScreen ();
		}
		*/
		// 経路上を移動
		/*
		if (X > -3 && X < -2) {

			VY = 1;
		}
		if (X > -1 && X < 1) {
			VY = -1;
		}
		if (X > max.x) {
			// 破棄する
			DestroyObj();
		}
		*/
		float[] VL = load.goload (X, Y, VX, VY);
		VX = VL [0];
		VY = VL [1];
		if (X > max.x || Y > max.y) {
			// 破棄する
			DestroyObj();
		}
		// 画面外に出た場合に破壊する
		if ((X < min.x || max.x < X) || (Y < min.y || max.y < Y)) {
			// 破棄する
			DestroyObj();
		}
	}
}
