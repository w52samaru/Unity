﻿using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {
	public GameObject[] Left;
	public GameObject[] Right;
	
	Vector3[] LeftPositions;
	Vector3[] RightPositions;
	
	float EDGE = 20f;
	float TIME = 2f;
	float DELAY = .3f;
	
	// Use this for initialization
	void Start () {
		this.fadeIn (); //プレハブが生成されたらフェードイン処理を実行
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			fadeOut(); //クリックされたらフェードアウト処理を実行し、オブジェクトを破棄
		}
	}
	
	void fadeIn() {
		for (int i = 0; i < Left.Length; i++) {
			this.moveAction(Left[i], true, true, i);
		}
		for (int i = 0; i < Right.Length; i++) {
			this.moveAction(Right[i], true, false, i);
		}
	}
	
	void fadeOut() {
		for (int i = 0; i < Left.Length; i++) {
			this.moveAction(Left[i], false, true, i);
		}
		for (int i = 0; i < Right.Length; i++) {
			this.moveAction(Right[i], false, false, i);
		}
		Invoke ("DestroySelf", 1.5f);
	}
	
	void moveAction(GameObject pObj, bool isIn, bool isLeft, int pOrder) {
		if (isIn) {
			float xPos = 0;
			if (isLeft) {
				xPos = -EDGE;
			} else {
				xPos = EDGE;
			}
			iTween.MoveFrom(pObj, iTween.Hash (
				"x", xPos
				, "time", TIME
				, "delay", pOrder * DELAY // アニメーション開始をpOrder*DELAYの間遅らせる
				));
			iTween.FadeFrom(pObj, iTween.Hash(
				"a", 0f
				, "time", TIME
				, "delay", pOrder * DELAY
				));
		} else {
			float xPos = 0;
			if (isLeft) {
				xPos = -EDGE;
			} else {
				xPos = EDGE;
			}
			iTween.MoveTo(pObj, iTween.Hash (
				"x", xPos
				, "time", TIME
				, "delay", pOrder * DELAY // アニメーション開始をpOrder*DELAYの間遅らせる
				));
			iTween.FadeTo(pObj, iTween.Hash(
				"a", 0f
				, "time", TIME
				, "delay", pOrder * DELAY
				));
		}
	}
	
	void DestroySelf() {
		Destroy (this.gameObject);
	}
}